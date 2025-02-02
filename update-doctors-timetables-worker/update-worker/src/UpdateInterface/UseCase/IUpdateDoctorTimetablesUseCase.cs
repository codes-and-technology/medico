using UpdateEntitys;
using Presenters;

namespace UpdateInterface.UseCase;

public interface IUpdateDoctorTimetablesUseCase
{
    UpdateResult<DoctorTimetablesDateEntity> Update(DoctorTimetablesDateEntity doctorTimetables);
}