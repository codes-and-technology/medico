using Presenters;

namespace CreateInterface;

public interface IUserConsultingGateway
{
    Task<UserConsultingDto> GetUser(string email);
    Task<bool> GetCrm(int crm);
}
