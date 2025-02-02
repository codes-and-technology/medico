using Presenters;
using CreateEntitys;

namespace CreateInterface.Gateway.Queue;

public interface ICreateUserGateway
{
    Task<CreateResult<NotificationEntity>> CreateAsync(NotificationDto entity);
}