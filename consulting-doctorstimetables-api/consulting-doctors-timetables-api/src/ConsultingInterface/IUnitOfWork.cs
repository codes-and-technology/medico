namespace ConsultingInterface;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IAppointmentsRespository Appointments { get; }
    IDoctorsTimetablesDateRespository DoctorsTimetablesDate { get; }
    IDoctorsTimetablesTimesRespository DoctorsTimetablesTimes { get; }
}

