using ConsultingEntitys;
using ConsultingInterface;
using System.Linq.Expressions;

namespace DBGateways;

public class AppointmentDbGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IAppointmentDBGateway
{
    public Task<IEnumerable<AppointmentEntity>> FindAllAsync(Expression<Func<AppointmentEntity, bool>> predicate)
    {
        return Uow.Appointment.GetAllAsync(predicate);
    }
}
