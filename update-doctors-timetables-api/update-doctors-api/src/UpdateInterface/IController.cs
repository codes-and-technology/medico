using UpdateEntitys;
using Presenters;

namespace UpdateInterface;

public interface IController
{
    Task<ResultDto<List<DoctorTimetablesTimeEntity>>> UpdateDoctorAsync(UpdateDoctorTimetablesDto updateDoctorTimetablesDto, string token, string doctorId);
}