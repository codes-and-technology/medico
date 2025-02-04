using Entitys;
using Interfaces;
using System.Linq.Expressions;

namespace DBGateways;

public class DoctorsTimetablesDateDBGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IDoctorsTimetablesDateDBGateway
{
    public Task<IEnumerable<DoctorsTimetablesDateEntity>> FindAllAsync(Expression<Func<DoctorsTimetablesDateEntity, bool>> predicate)
    {
        return Uow.DoctorsTimetablesDate.GetAllAsync(predicate);
    }
}
