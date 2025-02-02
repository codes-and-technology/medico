using Presenters;
using Entitys;

namespace Controllers.Update
{
    public interface IUpdateNotificationController
    {
        Task<UpdateResult<NotificationEntity>> UpdateAsync(NotificationEntity entity);
    }
}
