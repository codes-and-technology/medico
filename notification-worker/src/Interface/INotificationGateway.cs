using Entitys;
using Presenters;

namespace Interface
{
    public interface INotificationGateway
    {
        Task<Result<NotificationEntity>> NotificationAsync(NotificationEntity entity);
    }
}
