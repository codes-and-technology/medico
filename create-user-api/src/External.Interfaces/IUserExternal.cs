using Presenters;
using Refit;

namespace External.Interfaces
{
    public interface IUserExternal
    {
        [Get("/api/User")]
        Task<IApiResponse<UserConsultingDto>> GetUser(string email);

        [Get("/api/CRM")]
        Task<IApiResponse<bool>> GetCRM(string crm);
    }
}
