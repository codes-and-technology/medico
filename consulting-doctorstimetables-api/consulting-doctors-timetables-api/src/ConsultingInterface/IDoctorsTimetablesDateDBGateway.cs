using ConsultingEntitys;

namespace ConsultingInterface;


public interface IDoctorsTimetablesDateDBGateway : IBaseDB
{
    Task<IEnumerable<DoctorsTimetablesDateEntity>> FindDoctorsTimetablesDateByIdDoctorAvailableAsync(string idDoctor);
}