using Presenters;
using Entitys;

namespace Interface;

public interface INotificationUseCase
{
    Result<NotificationEntity> Notification(NotificationEntity entity);
}