using CreateEntitys;
using Presenters;

namespace CreateInterface.Controllers;

public interface ICreateUserController
{
    Task<CreateResult<UserEntity>> CreateAsync(UserDto entity);
}