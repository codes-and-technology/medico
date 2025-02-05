using MassTransit;
using Entitys;
using Interfaces;
using Presenters;

namespace Rabbit.Consumer;

public class NotificationConsumer(INotificationController controller) : IConsumer<CreatedAppointmentDto>
{
    public async Task Consume(ConsumeContext<CreatedAppointmentDto> context)
    {
        var message = context.Message;
        Console.WriteLine($"Received message: {message}");
        await controller.NotificationAsync(message);
    }
}
