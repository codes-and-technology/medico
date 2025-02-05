using Entitys;
using Interfaces;
using System.Linq.Expressions;

namespace DBGateways;

public class AppointmentDbGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IAppointmentDBGateway
{
    public async Task AddAsync(AppointmentEntity entity) => await Uow.Appointment.AddAsync(entity);

    public async Task<IEnumerable<AppointmentEntity>> FindAllAsync(Expression<Func<AppointmentEntity, bool>> predicate) => await Uow.Appointment.FindAllAsync(predicate);
}
