using ConsultingEntitys;
using ConsultingInterface;

namespace DBGateways;

public class UserDbGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IUserDBGateway
{
    public Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        return Uow.Users.GetAllAsync(w => w.CRM != null);
    }
}
