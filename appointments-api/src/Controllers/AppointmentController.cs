using Interfaces;
using UseCases;
using Presenters;
using Entitys;

namespace Controllers;
public class AppointmentController(IDoctorsTimetablesDateDBGateway doctorsTimetablesDateDBGateway,
                                   IDoctorsTimetablesTimesDBGateway doctorsTimetablesTimesDBGateway,
                                   IAppointmentDBGateway appointmentDBGateway,
                                   ICreateAppointmentQueueGateway createAppointmentQueueGateway,
                                   IUserDBGateway userDBGateway) : IAppointmentController
{
    public async Task<ResultDto<CreatedAppointmentDto>> CreateAppointmentAsync(string idPatient, CreateAppointmentDto dto)
    {
        var result = new ResultDto<CreatedAppointmentDto>();
        var useCase = new AppointmentUseCase();

        try
        {
            string newId = Guid.NewGuid().ToString();

            await appointmentDBGateway.ExecuteInTransactionAsync(async () =>
            {
                var appointmentDbList = await appointmentDBGateway.FindAllAsync(a => a.IdDoctor == dto.IdDoctor);
                result = useCase.CreateAppointment(idPatient, dto, appointmentDbList);

                if (result.Success)
                {
                    var entity = new AppointmentEntity
                    {
                        Id = newId,
                        IdPatient = idPatient,
                        IdDoctor = dto.IdDoctor,
                        IdDoctorsTimetablesDate = dto.IdDoctorsTimetablesDate,
                        IdDoctorsTimetablesTime = dto.IdDoctorsTimetablesTime,
                        CreateDate = DateTime.Now,
                        Status = "PENDING"
                    };

                    await appointmentDBGateway.AddAsync(entity);
                }
            });

            if (!result.Success)
                return result;

            var dateDb = (await doctorsTimetablesDateDBGateway.FindAllAsync(d => d.Id == dto.IdDoctorsTimetablesDate)).FirstOrDefault();
            var timeDb = (await doctorsTimetablesTimesDBGateway.FindAsync(t => t.Id == dto.IdDoctorsTimetablesTime)).FirstOrDefault();

            var patient = (await userDBGateway.FindAllAsync(u => u.Id == idPatient)).FirstOrDefault();
            var doctor = (await userDBGateway.FindAllAsync(u => u.Id == dto.IdDoctor)).FirstOrDefault();

            var dtoResult = new CreatedAppointmentDto();
            dtoResult.Clone(newId: newId,
                dto: dto,
                doctorName: doctor.Name,
                doctorEmail: doctor.Email,
                idPatient: idPatient,
                patientName: patient.Name);

            if (dateDb != null && timeDb != null)
                dtoResult.AppointmentDate = $"{dateDb.AvailableDate.ToShortDateString()} às {timeDb.Time}";

            result.Data = dtoResult;
            await createAppointmentQueueGateway.SendMessage(result.Data);
        }
        catch (Exception ex)
        {
            result.Errors.Add(ex.Message);
        }

        return result;
    }

    public async Task<ResultDto<string>> ConfirmAsync(string idAppointment, bool isConfirmed)
    {
        var result = new ResultDto<string>();
        var useCase = new AppointmentUseCase();

        var appointmentDb = (await appointmentDBGateway.FindAllAsync(a => a.Id == idAppointment)).FirstOrDefault();
        result = useCase.CreateConfirm(appointmentDb, isConfirmed);

        if (result.Success)
        {
            await appointmentDBGateway.UpdateAsync(appointmentDb);
            await appointmentDBGateway.CommitAsync();
        }

        return result;
    }
}