using AuthEntitys;
using AuthUseCases.Utils;
using Microsoft.IdentityModel.Tokens;
using Presenters;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AuthUseCases;

public class AuthUseCase(byte[] secretJwt)
{
    public ResultDto<UserEntity> Auth(UserEntity user, LoginDoctorDto login)
    {
        var result = new ResultDto<UserEntity>();

        if (user == null)
            result.Errors.Add("Usuário ou senha inválidos");
        else
        {
            result.Valid(user);
            result.Valid(login);
        }

        return result;
    }

    public ResultDto<UserEntity> Auth(UserEntity user, LoginPatientDto login)
    {
        var result = new ResultDto<UserEntity>();

        if (user == null)
            result.Errors.Add("Usuário ou senha inválidos");
        else
        {
            result.Valid(user);
            result.Valid(login);
        }

        return result;
    }


    public ResultDto<string> Authenticate(string pwd, AuthEntity authEntity, UserEntity user)
    {
        ResultDto<string> result = new();

        if (!SecurityUtils.VerifyPassword(pwd, authEntity.Password))
            result.Errors.Add("Usuário ou senha inválido");
        else
            result.Data = GenerateToken(authEntity, user);

        return result;
    }

    private string GenerateToken(AuthEntity authEntity, UserEntity user)
    {
        //Gerando token
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenProperts = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(
            [
                new Claim("ID", user.Id),
                new Claim(ClaimTypes.Role, string.IsNullOrEmpty(user.CRM) ? "PATIENT" : "DOCTOR"),
            ]),
            Expires = DateTime.UtcNow.AddMinutes(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretJwt), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenProperts);
        return tokenHandler.WriteToken(token);
    }
}
