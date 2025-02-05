using MassTransit;
using Entitys;
using Interface;

namespace Rabbit.Consumer;

public class NotificationConsumer(INotificationGateway updateNotificationGateway) : IConsumer<NotificationEntity>
{
    public async Task Consume(ConsumeContext<NotificationEntity> context)
    {
        var message = context.Message;
        Console.WriteLine($"Received message: {message}");
        await updateNotificationGateway.NotificationAsync(message);
    }
}
