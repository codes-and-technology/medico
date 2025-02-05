using Entitys;
using Interfaces;

namespace Gateways.Database
{
    public class NotificationDbGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), INotificationDbGateway
    {
        public async Task AddAsync(NotificationEntity entity) => await Uow.Notifications.AddAsync(entity);
        public async Task UpdateAsync(NotificationEntity entity) => await Uow.Notifications.UpdateAsync(entity);
        
        public async Task<NotificationEntity> FindByIdAsync(string id) => await Uow.Notifications.FindByIdAsync(id);
    }
}