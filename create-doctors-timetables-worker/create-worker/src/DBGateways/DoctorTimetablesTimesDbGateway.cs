using System.Linq.Expressions;
using CreateEntitys;
using CreateInterface.DataBase;
using CreateInterface.Gateway.DB;

namespace DBGateways;

public class DoctorTimetablesTimesDbGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IDoctorTimetablesTimeDBGateway
{
    public async Task AddAsync(DoctorTimetablesTimeEntity entity) => await Uow.DoctorTimetablesTimes.AddAsync(entity);
    public async Task AddRangeAsync(List<DoctorTimetablesTimeEntity> entity) => await Uow.DoctorTimetablesTimes.AddRageAsync(entity);

    public async Task<DoctorTimetablesTimeEntity> FindByIdAsync(string id) =>
        await Uow.DoctorTimetablesTimes.FindByIdAsync(Guid.Parse(id));

    public async Task<DoctorTimetablesTimeEntity> FirstOrDefaultAsync(
        Expression<Func<DoctorTimetablesTimeEntity, bool>> predicate) =>
        await Uow.DoctorTimetablesTimes.FirstOrDefaultAsync(predicate);
}