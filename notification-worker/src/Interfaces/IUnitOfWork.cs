
namespace Interfaces;

public interface IUnitOfWork : IDisposable
{
    INotificationRepository Notifications { get; }
    Task<int> CommitAsync();
}

