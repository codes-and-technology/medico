using Presenters;
using CreateEntitys;
using CreateInterface;
using CreateUseCases;

namespace CreateController;

public class CreateUserController(
    IUserDBGateway userDbGateway,
    IAuthDBGateway authDbGateway,
    ICacheGateway<UserEntity> cache) : IController
{
    public async Task<ResultDto<UserEntity>> CreateUserAsync(UserDto userDto, string crm, decimal? amount, string specialty, int? physicianAssessment)
    {
        var user = await userDbGateway.FirstOrDefaultAsync(f => f.Email.Equals(userDto.Email));

        var useCase = new CreateUseCase(userDto, user, crm, amount, specialty, physicianAssessment);

        var result = useCase.CreateUser();

        if (!result.Success)
        {
            return result;
        }

        await userDbGateway.AddAsync(result.Data);

        var authEntity = useCase.CreateAuth(result.Data, userDto.Password);

        await authDbGateway.AddAsync(authEntity.Data);

        await authDbGateway.CommitAsync();

        if (!string.IsNullOrEmpty(crm))
            await cache.ClearCacheAsync("Doctors");

        return result;
    }
}