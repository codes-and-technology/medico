using UpdateEntitys;

namespace UpdateInterface;

public interface IDoctorTimetablesQueueGateway
{
    Task SendMessage(DoctorTimetablesDateEntity entity);

}