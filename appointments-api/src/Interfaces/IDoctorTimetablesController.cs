using Presenters;

namespace Interfaces;

public interface IDoctorTimetablesController
{
    Task<ResultDto<List<DoctorsTimetablesDateDto>>> ConsultingTimetablesAsync(string idDoctor);
}