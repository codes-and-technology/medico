using CreateEntitys;
using Presenters;

namespace CreateInterface;

public interface IController
{
    Task<ResultDto<DoctorTimetablesDateEntity>> CreateDoctorAsync(CreateDoctorTimetablesDto createDoctorTimetablesDto, string token, string doctorId);
}