namespace Interfaces;

public interface IBaseDB 
{
    Task CommitAsync();
    Task ExecuteInTransactionAsync(Func<Task> action);
}