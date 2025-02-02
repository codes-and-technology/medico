using Presenters;
using Entitys;

namespace UseCases.Update
{
    public interface IUpdateNotificationUseCase
    {
        UpdateResult<NotificationEntity> Update(NotificationEntity entity);
    }
}
