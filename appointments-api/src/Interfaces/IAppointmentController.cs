using Entitys;
using Presenters;

namespace Interfaces;

public interface IAppointmentController
{
    Task<ResultDto<CreatedAppointmentDto>> CreateAppointmentAsync(string idUser, CreateAppointmentDto dto);
    Task<ResultDto<string>> ConfirmAsync(string idAppointment, bool isConfirmed);
    Task<ResultDto<List<AppointmentReportDto>>> ConsultAppointment(string idPatient);
    Task<ResultDto<AppointmentEntity>> DeleteAppointment(string idAppointment, string patientId);
}