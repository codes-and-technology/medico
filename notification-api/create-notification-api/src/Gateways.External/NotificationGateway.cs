using External.Interfaces;
using Presenters;

namespace Gateways.External;

public class NotificationGateway(INotificationExternal notificationAPI): INotificationGateway
{
    public async Task<NotificationDto> GetAllAsync(string token)
    {
        var result = await notificationAPI.Get(token);

        if (!result.IsSuccessStatusCode)
            throw new Exception("Falha ao tentar consultar horários");

        return result.Content.Data.FirstOrDefault();
    }
}