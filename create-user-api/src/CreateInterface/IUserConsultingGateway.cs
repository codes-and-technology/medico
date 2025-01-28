using Presenters;
using Presenters.Enum;

namespace CreateInterface;

public interface IUserConsultingGateway
{
    Task<UserConsultingDto> GetUser(string email);
    Task<bool> DocumentExists(string value, DocumentType documentType);
}
