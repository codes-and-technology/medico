using Interfaces;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Presenters;

namespace Rabbit.Producer;

public class CreateAppointmentProducer(ISendEndpointProvider sendEndpointProvider, IConfiguration configuration) : ICreateAppointmentProducer
{
    public async Task SendMessage(CreatedAppointmentDto dto)
    {
        var host = configuration["Rabbit:Host"];
        var queue = "appointment-create";
        var sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri($"rabbitmq://{host}/{queue}"));

        await sendEndpoint.Send(dto);
    }
}
