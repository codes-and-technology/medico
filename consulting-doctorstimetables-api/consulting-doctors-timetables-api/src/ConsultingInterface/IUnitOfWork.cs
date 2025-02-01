namespace ConsultingInterface;

public interface IUnitOfWork : IDisposable
{
    IDoctorsTimetablesDateRepository DoctorsTimetablesDate { get; }
    IDoctorsTimetablesTimesRepository DoctorsTimetablesTimes { get; }
}

