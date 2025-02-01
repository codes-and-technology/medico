using CreateEntitys;
using CreateInterface;

namespace DBGateways;

public class DoctorTimetablesDate(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IDoctorTimetablesDate
{
    public Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        return Uow.Users.GetAllAsync(w => w.CRM != null);
    }
}
