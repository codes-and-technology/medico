using System.Linq.Expressions;
using CreateEntitys;

namespace CreateInterface;

public interface IUserDBGateway: IBaseDB
{
    Task AddAsync(UserEntity entity);
    Task<UserEntity> FindByIdAsync(Guid id);    
    Task<UserEntity> FirstOrDefaultAsync(Expression<Func<UserEntity, bool>> predicate);
}