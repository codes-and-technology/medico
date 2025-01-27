using CreateEntitys;
using Presenters;
using Presenters.Enum;

namespace CreateUseCases;

public class CreateUseCase
{
    private readonly UserDto _userDto;
    private readonly UserConsultingDto _userConsultingDto;
    private readonly UserType _userType;
    private readonly bool _hasCrm;
    private readonly int? _crm;

    public CreateUseCase(UserDto userDto, UserConsultingDto userConsultingDto, UserType userType, int? crm, bool hasCrm)
    {
        _userDto = userDto;        
        _userConsultingDto = userConsultingDto;
        _userType = userType;
        _hasCrm =hasCrm;
        _crm = crm; 
    }

    public ResultDto<UserEntity> CreateUser()
    {
        var result = new ResultDto<UserEntity>();
        result.Valid(_userDto);

        if (_userDto.Email.Equals(_userConsultingDto.Email))
        {
            result.Errors.Add("Email já existe");        
            return result;
        }

        if (_userType == UserType.Doctor && _hasCrm)
        {
            result.Errors.Add("CRM já existe");
            return result;
        }

        if (result.Errors.Count > 0)
            return result;

        return CreateUserEntity();
    }

    private ResultDto<UserEntity> CreateUserEntity()
    {
        var result = new ResultDto<UserEntity>();
        var contact = new UserEntity
        {
            Id = Guid.NewGuid(),
            Name = _userDto.Name,
            Email = _userDto.Email,
            CreatedDate = DateTime.Now,
            crm = _crm,
            UserType = _userType,
        };

        result.Data = contact;
        return result;
    }
}
