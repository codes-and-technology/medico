using MassTransit;
using Entitys;
using Gateways.Queue;


namespace Rabbit.Consumer.Update;

public class UpdateNotificationConsumer(IUpdateNotificationGateway updateNotificationGateway) : IConsumer<NotificationEntity>
{
    private readonly IUpdateNotificationGateway _updateNotificationGateway = updateNotificationGateway;

    public async Task Consume(ConsumeContext<NotificationEntity> context)
    {
        var message = context.Message;
        Console.WriteLine($"Received message: {message}");
        var result = await _updateNotificationGateway.UpdateAsync(message);

        if (!result.Success)
        {
            throw new Exception(String.Join("|", result.Errors));
        }
    }
}
