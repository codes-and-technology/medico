using Entitys;
using System.Linq.Expressions;

namespace Interfaces;


public interface IDoctorsTimetablesTimesDBGateway : IBaseDB
{
    Task<IEnumerable<DoctorsTimetablesTimesEntity>> FindAsync(Expression<Func<DoctorsTimetablesTimesEntity, bool>> predicate);
}