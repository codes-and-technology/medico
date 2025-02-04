using CreateEntitys;
using Presenters;
using Presenters.Enum;

namespace CreateInterface;

public interface IController
{
    Task<ResultDto<UserEntity>> CreateUserAsync(UserDto userDto, string crm, decimal? amount, string specialty, int? physicianAssessment);
}