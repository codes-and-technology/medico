using ConsultingEntitys;
using System.Linq.Expressions;

namespace ConsultingInterface;


public interface IDoctorsTimetablesTimesDBGateway : IBaseDB
{
    Task<IEnumerable<DoctorsTimetablesTimesEntity>> FindAsync(Expression<Func<DoctorsTimetablesTimesEntity, bool>> predicate);
}