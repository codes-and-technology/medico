using CreateEntitys;

namespace CreateInterface;

public interface IDoctorTimetablesProducer
{
    Task SendMessage(DoctorTimetablesDateEntity entity);
}