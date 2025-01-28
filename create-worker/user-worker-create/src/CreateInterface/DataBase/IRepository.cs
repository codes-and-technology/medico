using CreateEntitys;
using System.Linq.Expressions;

namespace CreateInterface.DataBase;
public interface IRepository<T> where T : EntityBase
{
    Task AddAsync(T entity);
    Task<T> FindByIdAsync(Guid id);
    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
}
