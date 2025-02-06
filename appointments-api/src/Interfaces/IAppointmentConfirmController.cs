using Presenters;

namespace Interfaces;

public interface IAppointmentConfirmController
{
    Task<ResultDto<string>> ConfirmAsync(string idAppointment);
}