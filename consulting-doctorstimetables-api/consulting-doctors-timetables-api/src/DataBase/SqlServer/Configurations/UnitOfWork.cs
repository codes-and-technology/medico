using ConsultingInterface;

namespace DataBase.SqlServer.Configurations;

public class UnitOfWork : IUnitOfWork
{

    private readonly ApplicationDbContext _dbContext;
    public IDoctorsTimetablesDateRepository DoctorsTimetablesDate { get; }
    public IDoctorsTimetablesTimesRepository DoctorsTimetablesTimes { get; }

    public UnitOfWork(ApplicationDbContext dbContext, 
                      IDoctorsTimetablesDateRepository doctorsTimetablesDateRespository,
                      IDoctorsTimetablesTimesRepository doctorsTimetablesTimesRespository)
    {
        _dbContext = dbContext;
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
