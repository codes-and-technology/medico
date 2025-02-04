using System.Linq.Expressions;
using Entitys.Base;

namespace Interfaces;

public interface IRepository<T> where T : EntityBase
{
    Task AddAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
}
