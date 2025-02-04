using Entitys;

namespace Gateways.Database
{
    public interface IUserDBGateway : IBaseDB
    {
        //Task AddAsync(NotificationEntity entity);
        //Task UpdateAsync(NotificationEntity entity);
        Task<UserEntity> FindByIdAsync(Guid id);
    }
}
