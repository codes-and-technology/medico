using Presenters;
using Refit;

namespace External.Interfaces
{
    public interface IUserExternal
    {
        [Get("/api/User")]
        Task<IApiResponse<UserConsultingDto>> GetUser(string email);

        [Get("/api/Document")]
        Task<IApiResponse<bool>> GetDocument(string value, int typeId);
    }
}
