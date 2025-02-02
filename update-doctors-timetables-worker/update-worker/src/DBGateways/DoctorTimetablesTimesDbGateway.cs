using System.Linq.Expressions;
using UpdateEntitys;
using UpdateInterface.DataBase;
using UpdateInterface.Gateway.DB;

namespace DBGateways;

public class DoctorTimetablesTimesDbGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IDoctorTimetablesTimeDBGateway
{

    public async Task UpdateRangeAsync(List<DoctorTimetablesTimeEntity> entityList) => await Uow.DoctorTimetablesTimes.UpdateRangeAysnc(entityList);

    public void Update(DoctorTimetablesTimeEntity entity) =>
        Uow.DoctorTimetablesTimes.Update(entity);

    
}