using System.Linq.Expressions;
using CreateEntitys;
using CreateInterface;

namespace DBGateways;

public class AuthDbGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IAuthDBGateway
{
    public async Task AddAsync(AuthEntity entity)
    {
        await Uow.Auths.AddAsync(entity);
    }

    public async Task<AuthEntity> FindByIdAsync(Guid id)
    {
        return await Uow.Auths.FindByIdAsync(id);
    }

    public async Task<AuthEntity> FirstOrDefaultAsync(Expression<Func<AuthEntity, bool>> predicate)
    {
        return await Uow.Auths.FirstOrDefaultAsync(predicate);
    }
}
