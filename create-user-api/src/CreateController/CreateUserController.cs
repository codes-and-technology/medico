using Presenters;
using CreateEntitys;
using CreateInterface;
using CreateUseCases;
using Presenters.Enum;

namespace CreateController;

public class CreateUserController(IUserConsultingGateway userConsulting, IUserQueueGateway userQueuGateway) : IController
{
    private readonly IUserConsultingGateway _userConsulting = userConsulting;
    private readonly IUserQueueGateway _userQueuGateway = userQueuGateway;

    public async Task<ResultDto<UserEntity>> CreateUserAsync(UserDto userDtor, UserType userType, int? crm)
    {
        var user = await _userConsulting.GetUser(userDtor.Email);
        var crmExists = false;

        if (userType == UserType.Doctor)
            crmExists = await _userConsulting.GetCrm(crm.Value);

        var createContactUseCase = new CreateUseCase(userDtor, user, userType, crm, crmExists);

        var result = createContactUseCase.CreateUser();

        if (result.Success)
            await _userQueuGateway.SendMessage(result.Data);

        return result;
    }
}
