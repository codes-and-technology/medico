using Entitys;
using Interfaces;

namespace DBGateways;

public class UserDbGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IUserDBGateway
{
    public Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        return Uow.Users.GetAllAsync(w => w.CRM != null && w.Amount != null && w.Specialty != null && w.Score.HasValue);
    }
}
