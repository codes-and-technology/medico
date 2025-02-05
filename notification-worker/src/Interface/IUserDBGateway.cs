using Entitys;

namespace Interface
{
    public interface IUserDBGateway : IBaseDB
    {
        Task<UserEntity> FindByIdAsync(Guid id);
    }
}
