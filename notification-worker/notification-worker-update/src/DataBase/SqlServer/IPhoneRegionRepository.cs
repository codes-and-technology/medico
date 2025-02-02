using Entitys;

namespace DataBase.SqlServer;

public interface IPhoneRegionRepository : IRepository<PhoneRegionEntity>
{
    Task<PhoneRegionEntity> GetByRegionNumberAsync(short regionNumber);
}
