using System.Linq.Expressions;
using AuthEntitys.Base;

namespace AuthInterface;

public interface IRepository<T> where T : EntityBase
{
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task<T> FindByIdAsync(Guid id);
    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    Task AddRageAsync(List<T> entity);
}
