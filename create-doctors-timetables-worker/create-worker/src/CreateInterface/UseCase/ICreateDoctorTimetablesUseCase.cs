using CreateEntitys;
using Presenters;

namespace CreateInterface.UseCase;

public interface ICreateDoctorTimetablesUseCase
{
    CreateResult<DoctorTimetablesDateEntity> Create(DoctorTimetablesDateEntity doctorTimetables);
}