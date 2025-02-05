using Entitys;
using DataBase.SqlServer.Configurations;
using Interface;

namespace Gateways.Database
{
    public class DoctorsTimetablesTimesDBGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IDoctorsTimetablesTimesDBGateway
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
        public async Task<DoctorsTimetablesTimesEntity> FindByIdAsync(Guid id)
        {
            return await Uow.TimetablesTimes.FindByIdAsync(id);
        }
    }
}