using Presenters;

namespace Interfaces
{
    public interface ICreateAppointmentQueueGateway
    {
        Task SendMessage(CreatedAppointmentDto dto);
    }
}
