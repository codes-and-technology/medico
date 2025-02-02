using ConsultingEntitys;
using System.Linq.Expressions;

namespace ConsultingInterface;

public interface IAppointmentDBGateway : IBaseDB
{
    Task<IEnumerable<AppointmentEntity>> FindAllAsync(Expression<Func<AppointmentEntity, bool>> predicate);
}