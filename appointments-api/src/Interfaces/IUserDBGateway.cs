using Entitys;

namespace Interfaces;


public interface IUserDBGateway: IBaseDB
{
    Task<IEnumerable<UserEntity>> GetAllAsync();
}