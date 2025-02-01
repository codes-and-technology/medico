using System.Linq.Expressions;
using ConsultingEntitys.Base;

namespace ConsultingInterface;

public interface IRepository<T> where T : EntityBase
{
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
}
