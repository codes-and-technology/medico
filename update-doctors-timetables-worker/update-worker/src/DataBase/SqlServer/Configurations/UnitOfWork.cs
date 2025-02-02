using UpdateInterface.DataBase;

namespace DataBase.SqlServer.Configurations;

public class UnitOfWork(
    ApplicationDbContext dbContext,
    IDoctorTimetablesDateRepository doctorTimetablesDateRepository,
    IDoctorTimetablesTimeRepository doctorTimetablesTimeRepository)
    : IUnitOfWork
{
    public IDoctorTimetablesDateRepository DoctorTimetablesDates { get; } = doctorTimetablesDateRepository;
    public IDoctorTimetablesTimeRepository DoctorTimetablesTimes { get; } = doctorTimetablesTimeRepository;

    public async Task<int> CommitAsync()
    {
        return await dbContext.SaveChangesAsync();
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
            dbContext.Dispose();
        }
    }
}
