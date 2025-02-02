using Entitys;
using Presenters;

namespace Gateways.Queue
{
    public interface IUpdateNotificationGateway
    {
        Task<UpdateResult<NotificationEntity>> UpdateAsync(NotificationEntity entity);
    }
}
