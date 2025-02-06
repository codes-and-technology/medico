using Entitys.Base;
using System.Linq.Expressions;

namespace Interfaces;

public interface IRepository<T> where T : EntityBase
{
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> FindAllAsync(string sqlQuery, params object[] parameters);
}
