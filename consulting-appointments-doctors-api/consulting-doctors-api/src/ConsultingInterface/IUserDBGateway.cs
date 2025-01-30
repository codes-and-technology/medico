using ConsultingEntitys;

namespace ConsultingInterface;


public interface IUserDBGateway: IBaseDB
{
    Task<IEnumerable<UserEntity>> GetAllAsync();
}