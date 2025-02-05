using Entitys;
using Interface;
using Presenters;

namespace Gateways.Database;

public class NotificationGateway : INotificationGateway
{
    public Task<Result<NotificationEntity>> NotificationAsync(NotificationEntity entity)
    {
        throw new NotImplementedException();
    }
}