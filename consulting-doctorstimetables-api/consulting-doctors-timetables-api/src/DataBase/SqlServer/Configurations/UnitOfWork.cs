using ConsultingInterface;

namespace DataBase.SqlServer.Configurations;

public class UnitOfWork : IUnitOfWork
{

    private readonly ApplicationDbContext _dbContext;
    public IUserRepository Users { get; }
    public IAppointmentsRespository Appointments { get; }
    public IDoctorsTimetablesDateRespository DoctorsTimetablesDate { get; }
    public IDoctorsTimetablesTimesRespository DoctorsTimetablesTimes { get; }

    public UnitOfWork(ApplicationDbContext dbContext, 
                      IUserRepository userRepository,
                      IAppointmentsRespository appointmentsRespository,
                      IDoctorsTimetablesDateRespository doctorsTimetablesDateRespository,
                      IDoctorsTimetablesTimesRespository doctorsTimetablesTimesRespository)
    {
        _dbContext = dbContext;
        Users = userRepository;
        Appointments = appointmentsRespository;
        DoctorsTimetablesDate = doctorsTimetablesDateRespository;
        DoctorsTimetablesTimes = doctorsTimetablesTimesRespository;
    }


    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _dbContext.Dispose();
        }
    }
}
