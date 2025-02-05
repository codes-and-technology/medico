using Entitys;
using System.Linq.Expressions;

namespace Interfaces;


public interface IUserDBGateway: IBaseDB
{
    Task<IEnumerable<UserEntity>> FindAllAsync(Expression<Func<UserEntity, bool>> predicate);
}