using Presenters;
using CreateEntitys;

namespace CreateInterface.Gateway.Queue;

public interface ICreateUserGateway
{
    Task<CreateResult<UserEntity>> CreateAsync(UserDto entity);
}