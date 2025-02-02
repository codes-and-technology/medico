using DeleteEntitys;
using DeleteInterface;
using MassTransit;
using Microsoft.Extensions.Configuration;

namespace Rabbit.Producer.Delete;

public class DoctorTimetablesProducer(ISendEndpointProvider sendEndpointProvider, IConfiguration configuration) : IDoctorTimetablesProducer
{
    public async Task SendMessage(DoctorTimetablesDateEntity entity)
    {
        var host = configuration["Rabbit:Host"];
        var queue = "delete-doctor-timetables";
        var sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri($"rabbitmq://{host}/{queue}"));

        await sendEndpoint.Send(entity);      
    }
}
