using Presenters;
using Entitys;

namespace Interface
{
    public interface INotificationController
    {
        Task<Result<NotificationEntity>> NotificationAsync(NotificationEntity entity);
    }
}
