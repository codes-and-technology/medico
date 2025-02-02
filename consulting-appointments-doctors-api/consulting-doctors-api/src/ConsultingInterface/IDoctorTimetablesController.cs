using Presenters;

namespace ConsultingInterface;

public interface IDoctorTimetablesController
{
    Task<ResultDto<List<DoctorsTimetablesDateDto>>> ConsultingTimetablesAsync(string idDoctor);
}