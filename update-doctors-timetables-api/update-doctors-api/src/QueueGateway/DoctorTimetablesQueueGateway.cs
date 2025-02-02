using UpdateEntitys;
using UpdateInterface;

namespace QueueGateway;

public class DoctorTimetablesQueueGateway(IDoctorTimetablesProducer doctorTimetablesProducer) : IDoctorTimetablesQueueGateway
{
    public async Task SendMessage(DoctorTimetablesDateEntity entity)
    {
        await doctorTimetablesProducer.SendMessage(entity);
    }
}