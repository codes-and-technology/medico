using Presenters;
using Entitys;

namespace Interfaces
{
    public interface INotificationController
    {
        Task NotificationAsync(CreatedAppointmentDto dto);
    }
}
