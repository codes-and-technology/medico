using Entitys;
using Rabbit.Producer.Create;

namespace Gateways.Queue;

public class NotificationQueueGateway(INotificationProducer notificationProducer) : INotificationQueueGateway
{
    public async Task SendMessage(NotificationEntity entity)
    {
        await notificationProducer.SendMessage(entity);
    }
}