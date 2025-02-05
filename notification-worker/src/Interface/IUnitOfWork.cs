
namespace Interface;

public interface IUnitOfWork : IDisposable
{
    INotificationRepository Notifications { get; }
    IAppointmentRepository Appointments { get; }
    IDoctorsTimetablesTimesRepository TimetablesTimes { get; }
    IDoctorsTimetablesDateRepository TimetablesDates { get; }
    Task<int> CommitAsync();
}

