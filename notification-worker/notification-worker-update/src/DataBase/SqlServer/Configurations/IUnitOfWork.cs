namespace DataBase.SqlServer.Configurations;

public interface IUnitOfWork : IDisposable
{
    //IContactRepository Contacts { get; }
    //IPhoneRegionRepository PhoneRegions { get; }

    INotificationRepository Notifications { get; }

    Task<int> CommitAsync();
}

