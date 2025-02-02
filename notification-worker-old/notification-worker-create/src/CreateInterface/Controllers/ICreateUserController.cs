using CreateEntitys;
using Presenters;

namespace CreateInterface.Controllers;

public interface ICreateUserController
{
    Task<CreateResult<NotificationEntity>> CreateAsync(NotificationDto entity);
}