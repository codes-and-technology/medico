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

    public async Task<ResultDto<List<AppointmentReportDto>>> ConsultAppointment(string idPatient)
    {
        var entityList = await appointmentDBGateway.FindReportAsync(idPatient);

        List<AppointmentReportDto> dtoList = new();

        foreach (var entity in entityList)
        {
            dtoList.Add(new AppointmentReportDto
            {
                Id = entity.AG_ID,
                Status = entity.AG_Status,
                CreateDate = entity.AG_CreateDate,
                DeleteDate = entity.AG_DeleteDate,
                Doctor = new DoctorReportDto
                {
                    Id = entity.DO_Id,
                    Name = entity.DO_Name,
                    CPF = entity.DO_CPF,
                    Email = entity.DO_Email,
                    CRM = entity.DO_CRM,
                    CreateDate = entity.DO_CreateDate,
                    Amount = entity.DO_Amount,
                    Specialty = entity.DO_Specialty,
                    Score = entity.DO_Score
                },
                Patient = new PatientReportDto
                {
                    Id = entity.PA_Id,
                    Name = entity.PA_Name,
                    CPF = entity.PA_CPF,
                    Email = entity.PA_Email,
                    CRM = entity.PA_CRM,
                    CreateDate = entity.PA_CreateDate,
                    Amount = entity.PA_Amount,
                    Specialty = entity.PA_Specialty,
                    Score = entity.PA_Score
                },
                Date = new DateReportDto
                {
                    Id = entity.DT_Id,
                    IdDoctor = entity.DT_IdDoctor,
                    AvailableDate = entity.DT_AvailableDate,
                    CreateDate = entity.DT_CreateDate,
                    DeleteDate = entity.DT_DeleteDate
                },
                Time = new TimeReportDto
                {
                    Id = entity.TM_Id,
                    IdDoctorsTimetablesDate = entity.TM_IdDoctorsTimetablesDate,
                    Time = entity.TM_Time,
                    CreateDate = entity.TM_CreateDate,
                    DeleteDate = entity.TM_DeleteDate
                }
            });
        }

        return new ResultDto<List<AppointmentReportDto>>
        {
            Data = dtoList
        };
    }

    public async Task<ResultDto<AppointmentEntity>> DeleteAppointment(string idAppointment, string patientId)
    {
        var appointmentList = await appointmentDBGateway.FindAllAsync(a => a.Id == idAppointment);
        var useCase = new AppointmentUseCase();

        var result = useCase.CreateDeleteAppointment(appointmentList.FirstOrDefault(), patientId);

        if (!result.Success)
            return result;
        
        await appointmentDBGateway.UpdateAsync(result.Data);
        
        await appointmentDBGateway.CommitAsync();

        return result;
    }
}