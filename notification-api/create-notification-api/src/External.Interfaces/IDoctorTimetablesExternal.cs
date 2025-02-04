using Entitys;
using Presenters;
using Refit;

namespace External.Interfaces;

public interface IDoctorTimetablesExternal
{
    [Get("/doctors-timetables")]
    Task<IApiResponse<ResultDto<List<ConsultingDoctorTimetablesDateDto>>>> Get([Header("Authorization")] string authorization);

}