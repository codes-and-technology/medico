using AuthUseCases;
using AuthInterface;
using Presenters;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace AuthControllers;

public class AuthController(IUserDBGateway userDbGateway, IAuthDBGateway authDbGateway, IConfiguration configuration) : IController
{
    public async Task<ResultDto<string>> AuthAsync(LoginDto login)
    {
        var user = await userDbGateway.FirstOrDefaultAsync(f => f.Email.Equals(login.Email));

        var result = new ResultDto<string>();
        if (user == null)
        {
            result.Errors.Add("Usuário ou senha inválido");
            return result;
        }

        var auth = await authDbGateway.FirstOrDefaultAsync(f => f.IdUser.Equals(user.Id));

        var key = Encoding.ASCII.GetBytes(configuration["SecretJWT"]);
        var useCase = new AuthUseCase(user, login, key);

        result = useCase.Authenticate(login, auth, user);

        if (!result.Success)
            return result;

        auth.LastLoginDate = DateTime.Now;
        await authDbGateway.UpdateAsync(auth);
        await authDbGateway.CommitAsync();
        
        return result;
    }
}