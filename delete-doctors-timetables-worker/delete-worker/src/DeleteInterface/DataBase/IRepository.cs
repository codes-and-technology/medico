using DeleteEntitys;
using System.Linq.Expressions;

namespace DeleteInterface.DataBase;
public interface IRepository<T> where T : EntityBase
{
    Task Update(T entity);

    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
}
