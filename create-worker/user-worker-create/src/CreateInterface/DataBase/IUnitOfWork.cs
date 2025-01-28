namespace CreateInterface.DataBase;

public interface IUnitOfWork : IDisposable
{
    IDocumentRepository Documents { get; }
    Task<int> CommitAsync();
}

