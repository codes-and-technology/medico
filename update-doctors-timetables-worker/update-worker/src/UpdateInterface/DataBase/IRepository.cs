using UpdateEntitys;
using System.Linq.Expressions;

namespace UpdateInterface.DataBase;
public interface IRepository<T> where T : EntityBase
{
    Task UpdateRangeAysnc(List<T> entity);
    Task Update(T entity);
}
