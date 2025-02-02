using Entitys;

namespace Gateways.Database
{
    public interface IPhoneRegionDBGateway : IBaseDB
    {
        Task AddAsync(PhoneRegionEntity entity);
        Task<PhoneRegionEntity> GetByRegionNumberAsync(short regionNumber);
    }
}
