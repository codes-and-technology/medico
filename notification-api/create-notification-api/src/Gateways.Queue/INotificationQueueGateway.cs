using Entitys;

namespace Gateways.Queue;

public interface INotificationQueueGateway
{
    Task SendMessage(NotificationEntity entity);

}