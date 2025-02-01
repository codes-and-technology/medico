using System.Linq.Expressions;
using CreateEntitys;

namespace CreateInterface.Gateway.DB;

public interface IDoctorTimetablesDateDBGateway: IBaseDB
{
    Task AddAsync(DoctorTimetablesDateEntity entity);
    Task<DoctorTimetablesDateEntity> FindByIdAsync(string id);
    
    Task<DoctorTimetablesDateEntity> FirstOrDefaultAsync(Expression<Func<DoctorTimetablesDateEntity, bool>> predicate);
}