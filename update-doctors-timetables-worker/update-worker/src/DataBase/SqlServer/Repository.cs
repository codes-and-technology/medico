using UpdateEntitys;
using UpdateInterface.DataBase;
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

    public virtual async Task UpdateRangeAysnc(List<T> entity) => await Task.Run(() => _dbSet.UpdateRange(entity));
    public virtual async Task Update(T entity) => _dbSet.Update(entity);
}
