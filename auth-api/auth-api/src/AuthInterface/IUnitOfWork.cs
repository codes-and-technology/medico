namespace AuthInterface;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IAuthRepository Auths { get; }
    Task<int> CommitAsync();
}

