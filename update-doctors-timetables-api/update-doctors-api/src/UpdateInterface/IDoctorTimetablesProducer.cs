using UpdateEntitys;

namespace UpdateInterface;

public interface IDoctorTimetablesProducer
{
    Task SendMessage(DoctorTimetablesDateEntity entity);
}