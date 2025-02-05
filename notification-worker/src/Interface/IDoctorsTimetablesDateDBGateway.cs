using Entitys;

namespace Interface
{
    public interface IDoctorsTimetablesDateDBGateway : IBaseDB
    {
        //Task AddAsync(NotificationEntity entity);
        //Task UpdateAsync(NotificationEntity entity);
        Task<DoctorsTimetablesDateEntity> FindByIdAsync(Guid id);
    }
}
