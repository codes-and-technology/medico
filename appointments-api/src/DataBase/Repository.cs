using Entitys.Base;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
    public virtual async Task UpdateAsync(T entity) => _dbSet.Update(entity);
    public virtual async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate) => await _dbSet.Where(predicate).ToListAsync();
    public async Task<IEnumerable<T>> FindAllAsync(string sqlQuery, params object[] parameters) => await _dbSet.FromSqlRaw(sqlQuery, parameters).ToListAsync();
}
