using Entitys;

namespace Gateways.Database
{
    public interface IAppointmentDBGateway : IBaseDB
    {
        //Task AddAsync(NotificationEntity entity);
        //Task UpdateAsync(NotificationEntity entity);
        Task<AppointmentEntity> FindByIdAsync(Guid id);
    }
}
