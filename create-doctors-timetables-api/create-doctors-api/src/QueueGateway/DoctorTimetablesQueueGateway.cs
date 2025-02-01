using CreateEntitys;
using CreateInterface;

namespace QueueGateway;

public class DoctorTimetablesQueueGateway(IDoctorTimetablesProducer doctorTimetablesProducer) : IDoctorTimetablesQueueGateway
{
    public async Task SendMessage(DoctorTimetablesDateEntity entity)
    {
        await doctorTimetablesProducer.SendMessage(entity);
    }
}