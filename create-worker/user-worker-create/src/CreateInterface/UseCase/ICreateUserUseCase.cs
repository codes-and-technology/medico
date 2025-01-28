using CreateEntitys;
using Presenters;

namespace CreateInterface.UseCase;

public interface ICreateUserUseCase
{
    CreateResult<UserEntity> Create(UserDto userDto, ApplicationUser applicationUser);
}