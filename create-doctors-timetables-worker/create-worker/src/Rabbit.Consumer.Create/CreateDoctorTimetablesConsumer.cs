using CreateEntitys;
using CreateInterface.Gateway.Queue;
using MassTransit;

namespace Rabbit.Consumer.Create;

public class CreateDoctorTimetablesConsumer(ICreateDoctorTimetablesGateway createDoctorTimetablesGateway) : IConsumer<DoctorTimetablesDateEntity>
{
    public async Task Consume(ConsumeContext<DoctorTimetablesDateEntity> context)
    {
        var message = context.Message;
        Console.WriteLine($"Received message: {message}");
        var result = await createDoctorTimetablesGateway.CreateAsync(message);
    }
}
