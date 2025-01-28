using CreateEntitys;
using Presenters;
using Presenters.Enum;

namespace CreateUseCases;

public class CreateUseCase(UserDto userDto, UserConsultingDto userConsultingDto)
{
    public ResultDto<UserEntity> CreateUser()
    {
        var result = new ResultDto<UserEntity>();
        result.Valid(userDto);

        if (userDto.Email.ToLower().Equals(userConsultingDto.Email.ToLower(), StringComparison.InvariantCultureIgnoreCase))
        {
            result.Errors.Add("Email já existe");        
        } 
        if (userDto.CRM.Equals(userConsultingDto.CRM))
        {
            result.Errors.Add("CRM já existe");
        }

        return result.Errors.Count > 0 ? result : CreateUserEntity();
    }

    private ResultDto<UserEntity> CreateUserEntity()
    {
        var result = new ResultDto<UserEntity>();
        var contact = new UserEntity
        {
            Id = "1",
            Name = userDto.Name,
            Email = userDto.Email,
            CreateDate = DateTime.Now,
            CRM = userDto.CRM,
            CPF = userDto.DocumentNumber
        };

        result.Data = contact;
        return result;
    }
}
