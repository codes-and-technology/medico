using System.Linq.Expressions;
using DeleteEntitys;

namespace DeleteInterface.Gateway.DB;

public interface IDoctorTimetablesDateDBGateway : IBaseDB
{
    Task<DoctorTimetablesDateEntity> FirstOrDefaultAsync(Expression<Func<DoctorTimetablesDateEntity, bool>> predicate);
    void Update(DoctorTimetablesDateEntity entity);
}