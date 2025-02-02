using ConsultingEntitys;
using System.Linq.Expressions;

namespace ConsultingInterface;


public interface IDoctorsTimetablesDateDBGateway : IBaseDB
{
    Task<IEnumerable<DoctorsTimetablesDateEntity>> FindAllAsync(Expression<Func<DoctorsTimetablesDateEntity, bool>> predicate);
}