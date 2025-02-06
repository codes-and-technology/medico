using Entitys;

namespace Interfaces;

public interface IAppointmentRepository : IRepository<AppointmentEntity>
{
    Task<IEnumerable<AppointmentReportEntity>> FindReportAsync(string idPatient);
}