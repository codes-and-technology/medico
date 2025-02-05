using System.Linq.Expressions;
using Entitys.Base;
using Interfaces;
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

    public virtual async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate) => await _dbSet.Where(predicate).ToListAsync();
}
