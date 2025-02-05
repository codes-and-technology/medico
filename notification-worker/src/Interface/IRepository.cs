using Entitys;

namespace Interface;
public interface IRepository<T> where T : EntityBase
{
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task<T> FindByIdAsync(Guid id);
}
