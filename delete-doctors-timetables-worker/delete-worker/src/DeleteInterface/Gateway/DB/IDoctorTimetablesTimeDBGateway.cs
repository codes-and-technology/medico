using System.Linq.Expressions;
using DeleteEntitys;

namespace DeleteInterface.Gateway.DB;

public interface IDoctorTimetablesTimeDBGateway: IBaseDB
{
    void Update(DoctorTimetablesTimeEntity entity);
    Task<DoctorTimetablesTimeEntity> FirstOrDefaultAsync(Expression<Func<DoctorTimetablesTimeEntity, bool>> predicate);
    Task<List<DoctorTimetablesTimeEntity>> GetAllAsync(Expression<Func<DoctorTimetablesTimeEntity, bool>> predicate);
}
