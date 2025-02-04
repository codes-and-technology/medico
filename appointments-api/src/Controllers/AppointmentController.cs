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
            await appointmentDBGateway.ExecuteInTransactionAsync(async () =>
            {
                var appointmentDbList = await appointmentDBGateway.FindAllAsync(a => a.IdDoctor == dto.IdDoctor);
                var dateDb = await doctorsTimetablesDateDBGateway.FindAllAsync(d => d.Id == dto.IdDoctorsTimetablesDate);
                var timeDb = await doctorsTimetablesTimesDBGateway.FindAsync(t => t.Id == dto.IdDoctorsTimetablesTime);

                result = useCase.CreateAppointment(idPatient, dto, appointmentDbList, dateDb, timeDb);

                var entity = new AppointmentEntity
                {
                    IdPatient = idPatient,
                    IdDoctor = dto.IdDoctor,
                    IdDoctorsTimetablesDate = dto.IdDoctorsTimetablesDate,
                    IdDoctorsTimetablesTime = dto.IdDoctorsTimetablesTime,
                    CreateDate = DateTime.Now
                };

                await appointmentDBGateway.AddAsync(entity);
            });
        }
        catch (Exception ex)
        {
            result.Errors.Add(ex.Message);
        }

        return result;
    }
}