using Entitys;

namespace Rabbit.Producer.Create;

public interface IDoctorTimetablesProducer
{
    Task SendMessage(DoctorsTimetablesDateEntity entity);
}