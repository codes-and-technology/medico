using Entitys;
using DataBase.SqlServer.Configurations;

namespace Gateways.Database
{
    public class NotificationDBGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), INotificationDBGateway
    {
        public async Task AddAsync(NotificationEntity entity)
        {
            await Uow.Notifications.AddAsync(entity);
        }

        public async Task UpdateAsync(NotificationEntity entity)
        {
            await Uow.Notifications.UpdateAsync(entity);
        }

        public async Task<NotificationEntity> FindByIdAsync(Guid id)
        {
            return await Uow.Notifications.FindByIdAsync(id);
        }
    }
}