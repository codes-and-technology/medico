using UpdateEntitys;
using UpdateInterface.Gateway.Queue;
using MassTransit;

namespace Rabbit.Consumer.Update;

public class UpdateDoctorTimetablesConsumer(IUpdateDoctorTimetablesGateway createDoctorTimetablesGateway) : IConsumer<DoctorTimetablesDateEntity>
{
    public async Task Consume(ConsumeContext<DoctorTimetablesDateEntity> context)
    {
        var message = context.Message;
        Console.WriteLine($"Received message: {message}");
        var result = await createDoctorTimetablesGateway.UpdateAsync(message);
    }
}
