using Entitys;
using Presenters;
using Controllers;

namespace Gateways.Queue
{
    public class UpdateNotificationGateway(IUpdateNotificationController updateNotificationController) : IUpdateNotificationGateway
    {
        private readonly IUpdateNotificationController _updateNotificationController = updateNotificationController;

        public async Task<UpdateResult<NotificationEntity>> UpdateAsync(NotificationEntity entity)
        {
            return await _updateNotificationController.UpdateAsync(entity);
        }
    }
}
