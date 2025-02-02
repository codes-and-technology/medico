using CreateEntitys;
using Presenters;

namespace External.Interfaces;
using Refit;

public interface IDoctorTimetablesExternal
{
    [Get("/doctors-timetables")]
    Task<IApiResponse<List<ConsultingDoctorTimetablesDateDto>>> Get([Header("Authorization")] string authorization);

}