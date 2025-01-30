using AuthUseCases;
using CreateInterface;
using Presenters;

namespace CreateController;

public class CreateUserController(IUserDBGateway userDbGateway, IAuthDBGateway authDbGateway) : IController
{
    public async Task<ResultDto<string>> AuthAsync(LoginDto login)
    {
        var user = await userDbGateway.FirstOrDefaultAsync(f => f.Email.Equals(login.Email));
        var auth = await authDbGateway.FirstOrDefaultAsync(f => f.IdUser.Equals(user.Id));

        var useCase = new AuthUseCase(user, login);

        var result = useCase.Authenticate(login, auth, user);

        if (!result.Success)
            return result;

        auth.LastLoginDate = DateTime.Now;
        await authDbGateway.UpdateAsync(auth);
        await authDbGateway.CommitAsync();
        
        return result;
    }
}