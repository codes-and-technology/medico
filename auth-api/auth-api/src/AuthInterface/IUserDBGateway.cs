using AuthEntitys;
using System.Linq.Expressions;

namespace AuthInterface;

public interface IUserDBGateway: IBaseDB
{
    Task AddAsync(UserEntity entity);
    Task<UserEntity> FindByIdAsync(Guid id);    
    Task<UserEntity> FirstOrDefaultAsync(Expression<Func<UserEntity, bool>> predicate);
}