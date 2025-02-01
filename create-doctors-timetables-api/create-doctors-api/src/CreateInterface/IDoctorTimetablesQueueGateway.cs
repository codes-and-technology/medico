using CreateEntitys;

namespace CreateInterface;

public interface IDoctorTimetablesQueueGateway
{
    Task SendMessage(DoctorTimetablesDateEntity entity);

}