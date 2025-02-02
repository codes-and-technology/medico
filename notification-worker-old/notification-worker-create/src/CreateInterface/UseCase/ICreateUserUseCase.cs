using CreateEntitys;
using Presenters;

namespace CreateInterface.UseCase;

public interface ICreateUserUseCase
{
    CreateResult<NotificationEntity> Create(NotificationDto notificationDto, List<NotificationEntity> list);
}