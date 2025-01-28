using Presenters;
using CreateInterface;
using External.Interfaces;
using Presenters.Enum;

namespace ExternalInterfaceGateway;

public class UserConsultingGateway : IUserConsultingGateway
{
    private readonly IUserExternal _contactConsultingApi;

    public UserConsultingGateway(IUserExternal contactConsultingApi)
    {
        _contactConsultingApi = contactConsultingApi;
    }

    public async Task<UserConsultingDto> GetUser(string email)
    {
        var result = await _contactConsultingApi.GetUser(email);

        if (!result.IsSuccessStatusCode)
            throw new Exception("Falha ao tentar consultar usuario");

        return result.Content;
    }

    public async Task<bool> DocumentExists(string value, DocumentType documentType)
    {
        var result = await _contactConsultingApi.GetDocument(value, (int)documentType);

        if (!result.IsSuccessStatusCode)
            throw new Exception("Falha ao tentar consultar");

        return result.Content;
    }

}
