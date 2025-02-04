using Interfaces;

namespace DBGateways;

public class BaseDB(IUnitOfWork unitOfWork) : IBaseDB
{
    public readonly IUnitOfWork Uow = unitOfWork;


    public async Task ExecuteInTransactionAsync(Func<Task> action) => await Uow.ExecuteInTransactionAsync(action);
    public async Task CommitAsync() => await Uow.CommitAsync();
}