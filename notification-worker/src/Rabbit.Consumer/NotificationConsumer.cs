using MassTransit;
using Entitys;
using Interface;
using Presenters;

namespace Rabbit.Consumer;

public class NotificationConsumer(INotificationGateway notificationGateway) : IConsumer<CreatedAppointmentDto>
{
    public async Task Consume(ConsumeContext<CreatedAppointmentDto> context)
    {
        var message = context.Message;
        Console.WriteLine($"Received message: {message}");
        //await updateNotificationGateway.NotificationAsync(message);
    }
}
