using Entitys;

namespace Interface
{
    public interface IDoctorsTimetablesTimesDBGateway : IBaseDB
    {
        //Task AddAsync(NotificationEntity entity);
        //Task UpdateAsync(NotificationEntity entity);
        Task<DoctorsTimetablesTimesEntity> FindByIdAsync(Guid id);
    }
}
