using Entitys;

namespace Interface
{
    public interface INotificationDBGateway : IBaseDB
    {
        Task AddAsync(NotificationEntity entity);
        Task UpdateAsync(NotificationEntity entity);
        Task<NotificationEntity> FindByIdAsync(Guid id);
    }
}
