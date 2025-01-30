using Presenters;
using CreateEntitys;
using CreateInterface;
using CreateUseCases;

namespace CreateController;

public class CreateUserController(IUserDBGateway userDbGateway, IAuthDBGateway authDbGateway) : IController
{
    public async Task<ResultDto<UserEntity>> CreateUserAsync(UserDto userDto)
    {
        var user = await userDbGateway.FirstOrDefaultAsync(f => f.Email.Equals(userDto.Email));

        var useCase = new CreateUseCase(userDto, user);

        var result = useCase.CreateUser();

        if (!result.Success)
        {
            return result;
        }
        
        await userDbGateway.AddAsync(result.Data);

        var authEntity = useCase.CreateAuth(result.Data, userDto.Password);
        
        await authDbGateway.AddAsync(authEntity.Data);

        await authDbGateway.CommitAsync();
        
        return result;
    }
}