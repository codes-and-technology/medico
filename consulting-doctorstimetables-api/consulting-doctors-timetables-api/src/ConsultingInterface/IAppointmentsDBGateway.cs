using ConsultingEntitys;

namespace ConsultingInterface;

public interface IAppointmentsDBGateway : IBaseDB
{
    Task<IEnumerable<AppointmentsEntity>> FindAppointmentsUnavailableAsync(string idDoctor, string idDoctorsTimetablesDate, string idDoctorsTimetablesTime);
}