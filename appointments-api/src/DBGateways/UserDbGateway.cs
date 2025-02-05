using Entitys;
using Interfaces;
using System.Linq.Expressions;

namespace DBGateways;

public class UserDbGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IUserDBGateway
{
    public Task<IEnumerable<UserEntity>> FindAllAsync(Expression<Func<UserEntity, bool>> predicate)
    {
        return Uow.Users.FindAllAsync(predicate);
    }
}
