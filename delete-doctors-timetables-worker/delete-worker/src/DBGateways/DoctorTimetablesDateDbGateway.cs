using System.Linq.Expressions;
using DeleteEntitys;
using DeleteInterface.DataBase;
using DeleteInterface.Gateway.DB;

namespace DBGateways;

public class DoctorTimetablesDateDbGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IDoctorTimetablesDateDBGateway
{
    public async Task<DoctorTimetablesDateEntity> FirstOrDefaultAsync(Expression<Func<DoctorTimetablesDateEntity, bool>> predicate)
    => await Uow.DoctorTimetablesDates.FirstOrDefaultAsync(predicate);

    public void Update(DoctorTimetablesDateEntity entity)
    => Uow.DoctorTimetablesDates.Update(entity);
    
}
