using Interfaces;
using UseCases;
using Presenters;
using Entitys;

namespace Controllers;
public class AppointmentController(IDoctorsTimetablesDateDBGateway doctorsTimetablesDateDBGateway, IDoctorsTimetablesTimesDBGateway doctorsTimetablesTimesDBGateway, IAppointmentDBGateway appointmentDBGateway) : IAppointmentController
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
                        CreateDate = DateTime.Now
                    };

                    await appointmentDBGateway.AddAsync(entity);
                }
            });

            var dateDb = (await doctorsTimetablesDateDBGateway.FindAllAsync(d => d.Id == dto.IdDoctorsTimetablesDate)).FirstOrDefault();
            var timeDb = (await doctorsTimetablesTimesDBGateway.FindAsync(t => t.Id == dto.IdDoctorsTimetablesTime)).FirstOrDefault();

            var dtoResult = new CreatedAppointmentDto();
            dtoResult.Clone(newId, dto);

            if(dateDb != null && timeDb != null)
                dtoResult.AppointmentDate = $"{dateDb.AvailableDate:dd/MM/YYYY} {timeDb.Time}";

            result.Data = dtoResult;

            //TODO: Enviar para fila de notificação de agendamento solicitado, pendente aprovação

        }
        catch (Exception ex)
        {
            result.Errors.Add(ex.Message);
        }

        return result;
    }
}