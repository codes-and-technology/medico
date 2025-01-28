using CreateInterface.DataBase;

namespace DataBase.SqlServer.Configurations;

public class UnitOfWork : IUnitOfWork
{

    private readonly ApplicationDbContext _dbContext;
    public IDocumentRepository Documents { get; }

    public UnitOfWork(ApplicationDbContext dbContext,
        IDocumentRepository documentRepository)
    {
        _dbContext = dbContext;
        Documents = documentRepository;
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
