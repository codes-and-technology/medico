using DeleteEntitys;
using DeleteInterface.DataBase;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataBase.SqlServer;

public class Repository<T> : IRepository<T> where T : EntityBase
{
    protected ApplicationDbContext _context;
    protected DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public virtual async Task Update(T entity) => _dbSet.Update(entity);

    public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate) => await _dbSet.FirstOrDefaultAsync(predicate);
    public virtual async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate) => await _dbSet.Where(predicate).ToListAsync();
}
