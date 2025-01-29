using CreateInterface;

namespace DataBase.SqlServer.Configurations;

public class UnitOfWork : IUnitOfWork
{

    private readonly ApplicationDbContext _dbContext;
    public IUserRepository Users { get; }
    public IAuthRepository Auths { get; }

    public UnitOfWork(ApplicationDbContext dbContext,
        IUserRepository userRepository, IAuthRepository auths)
    {
        _dbContext = dbContext;
        Users = userRepository;
        Auths = auths;
    }

    public async Task<int> CommitAsync()
    {
        return await _dbContext.SaveChangesAsync();
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
