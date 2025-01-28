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

    public async Task<ResultDto<UserEntity>> CreateUserAsync(UserDto userDto, UserType userType, int? crm)
    {
        var user = await _userConsulting.GetUser(userDto.Email);
        var hasDocument = await _userConsulting.DocumentExists(userDto.DocumentNumber, DocumentType.CPF);

        var hasCrm = false;
        if (userType == UserType.Doctor)
            hasCrm = await _userConsulting.DocumentExists(crm.Value.ToString(), DocumentType.CRM);

        var createContactUseCase = new CreateUseCase(userDto, user, userType, crm, hasCrm, hasDocument);

        var result = createContactUseCase.CreateUser();

        if (result.Success)
            await _userQueuGateway.SendMessage(result.Data);

        return result;
    }
}
