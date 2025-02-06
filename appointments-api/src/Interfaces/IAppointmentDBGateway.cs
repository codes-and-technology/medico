using Entitys;
using System.Linq.Expressions;

namespace Interfaces;

public interface IAppointmentDBGateway : IBaseDB
{
    Task<IEnumerable<AppointmentEntity>> FindAllAsync(Expression<Func<AppointmentEntity, bool>> predicate);
    Task AddAsync(AppointmentEntity entity);
    Task UpdateAsync(AppointmentEntity entity);
    Task<IEnumerable<AppointmentReportEntity>> FindReportAsync(string idPatient);
}