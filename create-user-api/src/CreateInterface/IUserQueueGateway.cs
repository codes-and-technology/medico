using CreateEntitys;

namespace CreateInterface;

public interface IUserQueueGateway
{
    Task SendMessage(UserEntity entity);

}
