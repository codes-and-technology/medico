namespace DataBase.SqlServer.Configurations;

public class UnitOfWork : IUnitOfWork
{

    private readonly ApplicationDbContext _dbContext;
    //public IContactRepository Contacts { get; }
    //public IPhoneRegionRepository PhoneRegions { get; }
    public INotificationRepository Notifications { get; }

    public UnitOfWork(ApplicationDbContext dbContext,
                        //IContactRepository contactRepository,
                        //IPhoneRegionRepository phoneRegions,
                        INotificationRepository notificationRepository)
    {
        _dbContext = dbContext;
        //Contacts = contactRepository;
        //PhoneRegions = phoneRegions;
        Notifications = notificationRepository;
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
