using Entitys;
using MassTransit;
using Microsoft.Extensions.Configuration;

namespace Rabbit.Producer.Create;

public class NotificationProducer(ISendEndpointProvider sendEndpointProvider, IConfiguration configuration) : INotificationProducer
{
    public async Task SendMessage(NotificationEntity entity)
    {
        var host = configuration["Rabbit:Host"];
        var queue = "create-notification";
        var sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri($"rabbitmq://{host}/{queue}"));

        await sendEndpoint.Send(entity);
    }
}
