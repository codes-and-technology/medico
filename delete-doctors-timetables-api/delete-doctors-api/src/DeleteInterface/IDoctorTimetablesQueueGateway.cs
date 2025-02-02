using DeleteEntitys;

namespace DeleteInterface;

public interface IDoctorTimetablesQueueGateway
{
    Task SendMessage(DoctorTimetablesDateEntity entity);

}