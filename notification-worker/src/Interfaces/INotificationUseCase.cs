using Presenters;
using Entitys;
using MimeKit;

namespace Interfaces;

public interface INotificationUseCase
{
    Result<CreatedAppointmentDto> Notification(CreatedAppointmentDto dto);
    Result<NotificationEntity> CreateEntity(Result<MimeMessage> emailResult, string id);
}