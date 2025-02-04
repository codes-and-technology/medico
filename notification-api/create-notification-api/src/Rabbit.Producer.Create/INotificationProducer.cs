using Entitys;

namespace Rabbit.Producer.Create;

public interface INotificationProducer
{
    Task SendMessage(NotificationEntity entity);
}