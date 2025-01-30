using CreateEntitys;
using Presenters;

namespace AuthUseCases;

public class AuthUseCase(UserEntity user, LoginDto login)
{
    public ResultDto<UserEntity> CreateUser()
    {
        var result = new ResultDto<UserEntity>();
        
        result.Valid(user);
        result.Valid(login);

        return result;
    }

    public ResultDto<string> Authenticate(LoginDto loginRequested, AuthEntity authEntity, UserEntity user)
    {
        ResultDto<string> result = new();

        if (loginRequested.Password != authEntity.Password)
            result.Errors.Add("Usuário ou senha inválido");
        else
        {
            result.Data = GenerateToken(authEntity, user);
        }

        return result;
    }

    private string GenerateToken(AuthEntity authEntity, UserEntity user)
    {
        return "TESTE TOKEN GERADO FAKE#";
    }
}
