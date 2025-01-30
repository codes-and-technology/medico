namespace ConsultingInterface;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
}

