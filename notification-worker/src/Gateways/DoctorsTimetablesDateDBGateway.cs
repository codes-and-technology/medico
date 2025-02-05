using Entitys;
using DataBase.SqlServer.Configurations;
using Interface;

namespace Gateways.Database
{
    public class DoctorsTimetablesDateDBGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IDoctorsTimetablesDateDBGateway
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
        */
        public async Task<DoctorsTimetablesDateEntity> FindByIdAsync(Guid id)
        {
            return await Uow.TimetablesDates.FindByIdAsync(id);
        }
    }
}