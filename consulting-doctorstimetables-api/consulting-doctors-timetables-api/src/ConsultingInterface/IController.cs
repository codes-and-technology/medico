using Presenters;

namespace ConsultingInterface;

public interface IController
{
    Task<ResultDto<List<DoctorsTimetablesDateDto>>> ConsultingDoctorsTimetablesDateAsync(string idDoctor);
}