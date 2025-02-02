using System.Linq.Expressions;
using DeleteEntitys;
using DeleteInterface.DataBase;
using DeleteInterface.Gateway.DB;

namespace DBGateways;

public class DoctorTimetablesTimesDbGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IDoctorTimetablesTimeDBGateway
{

    public void Update(DoctorTimetablesTimeEntity entity) =>
        Uow.DoctorTimetablesTimes.Update(entity);

    public async Task<DoctorTimetablesTimeEntity> FirstOrDefaultAsync(Expression<Func<DoctorTimetablesTimeEntity, bool>> predicate)
        => await  unitOfWork.DoctorTimetablesTimes.FirstOrDefaultAsync(predicate);
    
    public async Task<List<DoctorTimetablesTimeEntity>> GetAllAsync(Expression<Func<DoctorTimetablesTimeEntity, bool>> predicate)
    => await unitOfWork.DoctorTimetablesTimes.GetAllAsync(predicate);
}