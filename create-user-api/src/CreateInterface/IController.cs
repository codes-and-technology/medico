using CreateEntitys;
using Presenters;
using Presenters.Enum;

namespace CreateInterface;

public interface IController
{
    Task<ResultDto<UserEntity>> CreateUserAsync(UserDto userDto);
}