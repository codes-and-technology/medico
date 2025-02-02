namespace CreateInterface.DataBase;

public interface IUnitOfWork : IDisposable
{
    INotificationRepository Notifications { get; }
    Task<int> CommitAsync();
}

