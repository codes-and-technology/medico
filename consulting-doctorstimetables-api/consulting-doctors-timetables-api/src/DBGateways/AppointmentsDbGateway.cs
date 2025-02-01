using ConsultingEntitys;
using ConsultingInterface;

namespace DBGateways;

public class AppointmentsDbGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IAppointmentsDBGateway
{
    public Task<IEnumerable<AppointmentsEntity>> FindAppointmentsUnavailableAsync(string idDoctor, string idDoctorsTimetablesDate, string idDoctorsTimetablesTime)
    {
        return Uow.Appointments.GetAllAsync(a => a.IdDoctor == idDoctor 
                                              && a.IdDoctorsTimetablesDate == idDoctorsTimetablesDate 
                                              && a.IdDoctorsTimetablesTime == idDoctorsTimetablesTime);
    }
}
