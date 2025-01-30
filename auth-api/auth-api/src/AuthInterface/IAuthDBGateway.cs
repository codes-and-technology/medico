using System.Linq.Expressions;
using AuthEntitys;

namespace AuthInterface;

public interface IAuthDBGateway: IBaseDB
{
    Task UpdateAsync(AuthEntity entity);
    Task<AuthEntity> FindByIdAsync(Guid id);    
    Task<AuthEntity> FirstOrDefaultAsync(Expression<Func<AuthEntity, bool>> predicate);
}