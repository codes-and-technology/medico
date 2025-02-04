using Entitys;
using MassTransit;
using Microsoft.Extensions.Configuration;

namespace Rabbit.Producer.Create;

public class DoctorTimetablesProducer(ISendEndpointProvider sendEndpointProvider, IConfiguration configuration) : IDoctorTimetablesProducer
{
    public async Task SendMessage(DoctorsTimetablesDateEntity entity)
    {
        var host = configuration["Rabbit:Host"];
        var queue = "create-notification";
        var sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri($"rabbitmq://{host}/{queue}"));

        await sendEndpoint.Send(entity);      
    }
}
