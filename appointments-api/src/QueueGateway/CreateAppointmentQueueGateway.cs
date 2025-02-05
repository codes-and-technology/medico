using Interfaces;
using Presenters;

namespace QueueGateway;

public class CreateAppointmentQueueGateway(ICreateAppointmentProducer doctorTimetablesProducer) : ICreateAppointmentQueueGateway
{
    public async Task SendMessage(CreatedAppointmentDto dto)
    {
        await doctorTimetablesProducer.SendMessage(dto);
    }
}