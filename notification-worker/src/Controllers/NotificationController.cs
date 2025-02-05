using Entitys;
using Presenters;
using Interface;

namespace Controllers
{
    public class NotificationController(INotificationDBGateway notificationDBGateway,
                                         INotificationUseCase notificationUseCase) : INotificationController
    {
        private readonly INotificationDBGateway _notificationDBGateway = notificationDBGateway;
        private readonly INotificationUseCase _updateNotificationUseCase = notificationUseCase;

        public async Task<Result<NotificationEntity>> NotificationAsync(NotificationEntity entity)
        {
            var result = _updateNotificationUseCase.Notification(entity);

            if (result.Errors.Count > 0)
                return result;
            

            await _notificationDBGateway.UpdateAsync(entity);
            await _notificationDBGateway.CommitAsync();

            return result;
        }
    }
}
