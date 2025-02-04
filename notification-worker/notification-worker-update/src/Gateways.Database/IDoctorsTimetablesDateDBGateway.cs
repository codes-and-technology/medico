using Entitys;

namespace Gateways.Database
{
    public interface IDoctorsTimetablesDateDBGateway : IBaseDB
    {
        //Task AddAsync(NotificationEntity entity);
        //Task UpdateAsync(NotificationEntity entity);
        Task<DoctorsTimetablesDateEntity> FindByIdAsync(Guid id);
    }
}
