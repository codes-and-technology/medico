using Entitys;
using DataBase.SqlServer.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using System.Reflection.Metadata.Ecma335;

namespace Gateways.Database
{
    public class UserDBGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IUserDBGateway
    {
        /*
        public async Task AddAsync(UserEntity entity)
        {
            await Uow.Notifications.AddAsync(entity);
        }

        public async Task UpdateAsync(UserEntity entity)
        {
            await Uow.Notifications.UpdateAsync(entity);
        }
        public virtual async Task<UserEntity> FindByIdAsync(Guid id)
        {
            return null;
        }
        */
        public async Task<UserEntity> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}