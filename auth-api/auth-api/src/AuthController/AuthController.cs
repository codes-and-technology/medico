using AuthUseCases;
using AuthInterface;
using Presenters;
using System.Text;
using Microsoft.Extensions.Configuration;
using AuthEntitys;

namespace AuthControllers;

public class AuthController(IUserDBGateway userDbGateway, IAuthDBGateway authDbGateway, IConfiguration configuration) : IController
{
    public async Task<ResultDto<string>> AuthAsync(LoginDoctorDto login) => await AuthAsync(login, null);

    public async Task<ResultDto<string>> AuthAsync(LoginPatientDto login) => await AuthAsync(null, login);

    private async Task<ResultDto<string>> AuthAsync(LoginDoctorDto loginDoctor, LoginPatientDto loginPatient)
    {
        UserEntity user = null;
        var key = Encoding.ASCII.GetBytes(configuration["SecretJWT"]);
        AuthUseCase useCase = new AuthUseCase(key);
        ResultDto<string> result = new ResultDto<string>();
        ResultDto<UserEntity> valid = null;
        string pwd = string.Empty;


        if (loginDoctor != null)
        {
            // doctor
            user = await userDbGateway.FirstOrDefaultAsync(f => f.CRM.Equals(loginDoctor.CRM));
            valid = useCase.Auth(user, loginDoctor);
            pwd = loginDoctor.Password;
        }
        else
        {
            // patient
            user = await userDbGateway.FirstOrDefaultAsync(f => f.Email.Equals(loginPatient.Email) || f.CPF.Equals(loginPatient.CPF));
            valid = useCase.Auth(user, loginPatient);
            pwd = loginPatient.Password;
        }

        if (!valid.Success)
        {
            result.Errors.AddRange(valid.Errors);
            return result;
        }

        var auth = await authDbGateway.FirstOrDefaultAsync(f => f.IdUser.Equals(user.Id));


        result = useCase.Authenticate(pwd, auth, user);

        if (!result.Success)
            return result;

        auth.LastLoginDate = DateTime.Now;
        await authDbGateway.UpdateAsync(auth);
        await authDbGateway.CommitAsync();

        return result;

    }
}
