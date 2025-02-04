using Entitys;

namespace Gateways.Database
{
    public interface IDoctorsTimetablesTimesDBGateway : IBaseDB
    {
        //Task AddAsync(NotificationEntity entity);
        //Task UpdateAsync(NotificationEntity entity);
        Task<DoctorsTimetablesTimesEntity> FindByIdAsync(Guid id);
    }
}
