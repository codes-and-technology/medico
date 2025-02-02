using Entitys;
using DataBase.SqlServer.Configurations;

namespace Gateways.Database
{
    public class ContactDBGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IContactDBGateway
    {
        public async Task AddAsync(ContactEntity entity)
        {
            //await Uow.Contacts.AddAsync(entity);
        }

        public async Task UpdateAsync(ContactEntity entity)
        {
            //await Uow.Contacts.UpdateAsync(entity);
        }

        public async Task<ContactEntity> FindByIdAsync(Guid id)
        {
            //return await Uow.Contacts.FindByIdAsync(id);
            return null;
        }
    }
}