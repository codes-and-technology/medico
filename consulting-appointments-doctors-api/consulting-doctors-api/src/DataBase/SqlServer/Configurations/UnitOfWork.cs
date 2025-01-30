using ConsultingInterface;

namespace DataBase.SqlServer.Configurations;

public class UnitOfWork : IUnitOfWork
{

    private readonly ApplicationDbContext _dbContext;
    public IUserRepository Users { get; }

    public UnitOfWork(ApplicationDbContext dbContext,
        IUserRepository userRepository)
    {
        _dbContext = dbContext;
        Users = userRepository;
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
