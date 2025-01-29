using System.Linq.Expressions;
using CreateEntitys;

namespace CreateInterface;

public interface IAuthDBGateway: IBaseDB
{
    Task AddAsync(AuthEntity entity);
    Task<AuthEntity> FindByIdAsync(Guid id);
    
    Task<AuthEntity> FirstOrDefaultAsync(Expression<Func<AuthEntity, bool>> predicate);
}