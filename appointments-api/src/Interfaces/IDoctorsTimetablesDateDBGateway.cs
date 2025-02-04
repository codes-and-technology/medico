using Entitys;
using System.Linq.Expressions;

namespace Interfaces;


public interface IDoctorsTimetablesDateDBGateway : IBaseDB
{
    Task<IEnumerable<DoctorsTimetablesDateEntity>> FindAllAsync(Expression<Func<DoctorsTimetablesDateEntity, bool>> predicate);
}