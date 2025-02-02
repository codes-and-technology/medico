using System.Linq.Expressions;
using CreateEntitys;
using CreateInterface.DataBase;
using CreateInterface.Gateway.DB;

namespace DBGateways;

public class DoctorTimetablesDateDbGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IDoctorTimetablesDateDBGateway
{
    public async Task AddAsync(DoctorTimetablesDateEntity entity) => await Uow.DoctorTimetablesDates.AddAsync(entity);

    public async Task<DoctorTimetablesDateEntity> FindByIdAsync(string id) => await Uow.DoctorTimetablesDates.FindByIdAsync(Guid.Parse(id));
    
    public async Task<DoctorTimetablesDateEntity> FirstOrDefaultAsync(Expression<Func<DoctorTimetablesDateEntity, bool>> predicate) => await Uow.DoctorTimetablesDates.FirstOrDefaultAsync(predicate);
}
