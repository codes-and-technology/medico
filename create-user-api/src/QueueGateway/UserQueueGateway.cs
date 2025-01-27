using CreateEntitys;
using CreateInterface;

namespace QueueGateway;

public class UserQueueGateway : IUserQueueGateway
{
    public readonly IUserProducer _userProducer;

    public UserQueueGateway(IUserProducer userProducer) => _userProducer = userProducer;

    public async Task SendMessage(UserEntity entity) => await _userProducer.SendMessage(entity);
}
