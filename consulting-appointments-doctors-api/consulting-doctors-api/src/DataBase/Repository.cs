using System.Linq.Expressions;
using ConsultingEntitys.Base;
using ConsultingInterface;
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

    public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate) => await _dbSet.Where(predicate).ToListAsync();
}
