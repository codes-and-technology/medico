using Presenters;

namespace Interfaces;

public interface IAppointmentController
{
    Task<ResultDto<CreatedAppointmentDto>> CreateAppointmentAsync(string idUser, CreateAppointmentDto dto);
}