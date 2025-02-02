using CreateInterface.DataBase;

namespace DataBase.SqlServer.Configurations;

public class UnitOfWork : IUnitOfWork
{

    private readonly ApplicationDbContext _dbContext;
    public INotificationRepository Notifications { get; }
    public IPendingNotificationRepository PendingNotifications { get; }

    public UnitOfWork(ApplicationDbContext dbContext,
        INotificationRepository notificationRepository,
        IPendingNotificationRepository pendingNotifications
        )
    {
        _dbContext = dbContext;
        Notifications = notificationRepository;
        PendingNotifications = pendingNotifications;
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
