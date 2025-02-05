using Presenters;

namespace Interfaces;

public interface ICreateAppointmentProducer
{
    Task SendMessage(CreatedAppointmentDto dto);
}