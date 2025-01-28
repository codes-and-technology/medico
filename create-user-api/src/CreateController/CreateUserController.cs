using Presenters;
using CreateEntitys;
using CreateInterface;
using CreateUseCases;
using Presenters.Enum;

namespace CreateController;

public class CreateUserController(IUserConsultingGateway userConsulting) : IController
{
    private readonly IUserConsultingGateway _userConsulting = userConsulting;

    public async Task<ResultDto<UserEntity>> CreateUserAsync(UserDto userDto)
    {
        var user = await _userConsulting.GetUser(userDto.Email);

        var hasCrm = false;
        if (!string.IsNullOrEmpty(userDto.CRM))
            hasCrm = await _userConsulting.DocumentExists(userDto.CRM);

        var createContactUseCase = new CreateUseCase(userDto, user);

        var result = createContactUseCase.CreateUser();

        return result;
    }
}
