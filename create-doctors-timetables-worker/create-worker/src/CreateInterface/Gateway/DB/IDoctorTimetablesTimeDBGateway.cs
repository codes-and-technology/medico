using System.Linq.Expressions;
using CreateEntitys;

namespace CreateInterface.Gateway.DB;

public interface IDoctorTimetablesTimeDBGateway: IBaseDB
{
    Task AddAsync(DoctorTimetablesTimeEntity entity);
    Task AddRangeAsync(List<DoctorTimetablesTimeEntity> entity);
    Task<DoctorTimetablesTimeEntity> FindByIdAsync(string id);
    
    Task<DoctorTimetablesTimeEntity> FirstOrDefaultAsync(Expression<Func<DoctorTimetablesTimeEntity, bool>> predicate);
}
