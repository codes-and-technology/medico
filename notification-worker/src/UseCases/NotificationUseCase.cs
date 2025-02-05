using Presenters;
using Entitys;
using Interface;

namespace UseCases
{
    public class NotificationUseCase : INotificationUseCase
    {
        public Result<NotificationEntity> Notification(NotificationEntity entity)
        {
            var result = new Result<NotificationEntity>(entity);
            
            return result;
        }

      
    }
}
