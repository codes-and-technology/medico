namespace CreateInterface.DataBase;

public interface IUnitOfWork : IDisposable
{
    IDoctorTimetablesDateRepository DoctorTimetablesDates { get; }
    IDoctorTimetablesTimeRepository DoctorTimetablesTimes { get; }
    Task<int> CommitAsync();
}

