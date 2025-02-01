using CreateEntitys;
using Presenters;

namespace External.Interfaces;
using Refit;

public interface IDoctorTimetablesExternal
{
    [Get("/api/doctortimetables")]
    Task<IApiResponse<IEnumerable<ConsultingDoctorTimetablesDateDto>>> Get([Header("Authorization")] string authorization);

}