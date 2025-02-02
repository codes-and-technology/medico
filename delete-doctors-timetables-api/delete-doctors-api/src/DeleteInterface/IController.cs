using DeleteEntitys;
using Presenters;

namespace DeleteInterface;

public interface IController
{
    Task<ResultDto<List<DoctorTimetablesTimeEntity>>> DeleteDoctorAsync(DeleteDoctorTimetablesDto deleteDoctorTimetablesDto, string token, string doctorId);
}