using Entitys;
using System.Linq.Expressions;

namespace Interfaces;

public interface IAppointmentDBGateway : IBaseDB
{
    Task<IEnumerable<AppointmentEntity>> FindAllAsync(Expression<Func<AppointmentEntity, bool>> predicate);
    Task AddAsync(AppointmentEntity entity);
}