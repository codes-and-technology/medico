using Entitys;
using DataBase.SqlServer.Configurations;

namespace Gateways.Database
{
    public class PhoneRegionDBGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IPhoneRegionDBGateway
    {
        public async Task AddAsync(PhoneRegionEntity entity)
        {
            //await Uow.PhoneRegions.AddAsync(entity);
        }

        public async Task<PhoneRegionEntity> GetByRegionNumberAsync(short regionNumber)
        {
            //return await Uow.PhoneRegions.GetByRegionNumberAsync(regionNumber);
            return null;
        }
    }
}
