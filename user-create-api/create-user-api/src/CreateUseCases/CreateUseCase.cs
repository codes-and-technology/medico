using CreateController.Utils;
using CreateEntitys;
using CreateUseCases.Utils;
using Presenters;


namespace CreateUseCases;

public class CreateUseCase(UserDto userDto, UserEntity userEntity)
{
    public ResultDto<UserEntity> CreateUser()
    {
        var result = new ResultDto<UserEntity>();
        result.Valid(userDto);

        if (userEntity is not null && userDto.Email.ToLower().Equals(userEntity.Email.ToLower(), StringComparison.InvariantCultureIgnoreCase))
        {
            result.Errors.Add("Email já existe");        
        } 
        if(!CpfUtils.ValidateCpf(userDto.DocumentNumber))
        {
            result.Errors.Add("CPF inválido");
        }
        
        return result.Errors.Count > 0 ? result : CreateUserEntity();
    }

    public ResultDto<AuthEntity> CreateAuth(UserEntity currentUser, string password)
    {
        ResultDto<AuthEntity> result = new ();
        result.Valid(currentUser);

        AuthEntity authEntity = new()
        {
            Id = Guid.NewGuid().ToString(),
            CreateDate = DateTime.Now,
            Password = SecurityUtils.HashPassword(password),
            IdUser = currentUser.Id,
            LastLoginDate = DateTime.Now,
        };
        
        result.Data = authEntity;
        return result;
    }

    private ResultDto<UserEntity> CreateUserEntity()
    {
        var result = new ResultDto<UserEntity>();
        var user = new UserEntity
        {
            Id = Guid.NewGuid().ToString(),
            Name = userDto.Name,
            Email = userDto.Email,
            CreateDate = DateTime.Now,
            CRM = userDto.CRM,
            CPF = userDto.DocumentNumber
        };

        result.Data = user;
        return result;
    }
}
