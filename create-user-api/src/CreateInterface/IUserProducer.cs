using CreateEntitys;

namespace CreateInterface;

public interface IUserProducer
{
    Task SendMessage(UserEntity entity);
}
