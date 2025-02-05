using Entitys;

namespace Interfaces;
public interface IRepository<T> where T : EntityBase
{
    Task UpdateAsync(T entity);
    Task AddAsync(T entity);
    Task<T> FindByIdAsync(string id);
}
