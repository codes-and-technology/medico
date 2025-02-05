using Entitys;

namespace Interface
{
    public interface IAppointmentDBGateway : IBaseDB
    {
        //Task AddAsync(NotificationEntity entity);
        //Task UpdateAsync(NotificationEntity entity);
        Task<AppointmentEntity> FindByIdAsync(Guid id);
    }
}
