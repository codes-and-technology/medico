using DeleteEntitys;
using DeleteInterface.Gateway.Queue;
using MassTransit;

namespace Rabbit.Consumer.Delete;

public class DeleteDoctorTimetablesConsumer(IDeleteDoctorTimetablesGateway createDoctorTimetablesGateway) : IConsumer<DoctorTimetablesDateEntity>
{
    public async Task Consume(ConsumeContext<DoctorTimetablesDateEntity> context)
    {
        var message = context.Message;
        Console.WriteLine($"Received message: {message}");
        var result = await createDoctorTimetablesGateway.DeleteAsync(message);
    }
}
