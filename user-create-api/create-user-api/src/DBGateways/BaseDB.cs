using CreateInterface;

namespace DBGateways;

public class BaseDB(IUnitOfWork unitOfWork) : IBaseDB
{
    public readonly IUnitOfWork Uow = unitOfWork;

    public async Task CommitAsync()
    {
        await Uow.CommitAsync();
    }
}