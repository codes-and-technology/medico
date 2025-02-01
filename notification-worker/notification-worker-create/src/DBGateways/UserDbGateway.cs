using System.Linq.Expressions;
using CreateEntitys;
using CreateInterface.DataBase;
using CreateInterface.Gateway.DB;

namespace DBGateways;

public class UserDbGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IUserDBGateway
{
    public async Task AddAsync(NotificationEntity entity)
    {
        await Uow.Notifications.AddAsync(entity);
    }

    public async Task<NotificationEntity> FindByIdAsync(Guid id)
    {
        return await Uow.Notifications.FindByIdAsync(id);
    }

    public async Task<NotificationEntity> FirstOrDefaultAsync(Expression<Func<NotificationEntity, bool>> predicate)
    {
        return await Uow.Notifications.FirstOrDefaultAsync(predicate);
    }
}
