using System.Linq.Expressions;
using CreateEntitys.Base;
using CreateInterface;
using Microsoft.EntityFrameworkCore;

namespace DataBase;

public class Repository<T> : IRepository<T> where T : EntityBase
{
    protected ApplicationDbContext _context;
    protected DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public virtual async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
    public virtual async Task AddRageAsync(List<T> entity) => await _dbSet.AddRangeAsync(entity);
    public virtual async Task<T> FindByIdAsync(Guid id) => await _dbSet.FindAsync(id);
    public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate) => await _dbSet.FirstOrDefaultAsync(predicate);

}
