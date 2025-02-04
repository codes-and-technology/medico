using Entitys;
using Interfaces;
using System.Linq.Expressions;

namespace DBGateways;

public class DoctorsTimetablesTimesDBGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IDoctorsTimetablesTimesDBGateway
{
    public Task<IEnumerable<DoctorsTimetablesTimesEntity>> FindAsync(Expression<Func<DoctorsTimetablesTimesEntity, bool>> predicate)
    {
        return Uow.DoctorsTimetablesTimes.GetAllAsync(predicate);
    }
}
