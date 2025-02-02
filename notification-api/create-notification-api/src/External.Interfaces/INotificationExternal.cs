using Entitys;
using Presenters;
using Refit;

namespace External.Interfaces;

public interface INotificationExternal
{
    [Get("/notification")]
    Task<IApiResponse<ResultDto<List<NotificationDto>>>> Get([Header("Authorization")] string authorization);

}