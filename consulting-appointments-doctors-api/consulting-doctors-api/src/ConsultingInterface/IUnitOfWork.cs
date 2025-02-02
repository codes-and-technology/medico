namespace ConsultingInterface;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IDoctorsTimetablesDateRepository DoctorsTimetablesDate { get; }
    IDoctorsTimetablesTimesRepository DoctorsTimetablesTimes { get; }
}

