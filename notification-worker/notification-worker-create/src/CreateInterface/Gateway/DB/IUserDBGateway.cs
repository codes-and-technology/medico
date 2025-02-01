using System.Linq.Expressions;
using CreateEntitys;

namespace CreateInterface.Gateway.DB;

public interface IUserDBGateway: IBaseDB
{
    Task AddAsync(NotificationEntity entity);
    Task<NotificationEntity> FindByIdAsync(Guid id);
    
    Task<NotificationEntity> FirstOrDefaultAsync(Expression<Func<NotificationEntity, bool>> predicate);
}