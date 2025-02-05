using Entitys;

namespace Interfaces
{
    public interface INotificationDbGateway : IBaseDB
    {
        Task UpdateAsync(NotificationEntity entity);
        Task AddAsync(NotificationEntity entity);
        Task<NotificationEntity> FindByIdAsync(string id);
    }
}
