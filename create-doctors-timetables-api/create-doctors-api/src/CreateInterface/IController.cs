using CreateEntitys;
using Presenters;

namespace CreateInterface;

public interface IController
{
    Task<ResultDto<List<DoctorTimetablesTimeEntity>>> CreateDoctorAsync(CreateDoctorTimetablesDto createDoctorTimetablesDto, string token, string doctorId);
}