using System.Linq.Expressions;
using CreateEntitys.Base;

namespace CreateInterface;

public interface IRepository<T> where T : EntityBase
{
    Task AddAsync(T entity);
    Task<T> FindByIdAsync(Guid id);
    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    Task AddRageAsync(List<T> entity);
}
