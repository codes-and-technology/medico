using System.Linq.Expressions;
using CreateEntitys;
using CreateInterface;

namespace DBGateways;

public class UserDbGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IUserDBGateway
{
    public async Task AddAsync(UserEntity entity)
    {
        await Uow.Users.AddAsync(entity);
    }

    public async Task<UserEntity> FindByIdAsync(Guid id)
    {
        return await Uow.Users.FindByIdAsync(id);
    }

    public async Task<UserEntity> FirstOrDefaultAsync(Expression<Func<UserEntity, bool>> predicate)
    {
        return await Uow.Users.FirstOrDefaultAsync(predicate);
    }
}
