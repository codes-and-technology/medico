using DeleteEntitys;

namespace DeleteInterface;

public interface IDoctorTimetablesProducer
{
    Task SendMessage(DoctorTimetablesDateEntity entity);
}