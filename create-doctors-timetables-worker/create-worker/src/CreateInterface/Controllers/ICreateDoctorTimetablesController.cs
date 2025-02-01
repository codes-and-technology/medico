using CreateEntitys;
using Presenters;

namespace CreateInterface.Controllers;

public interface ICreateDoctorTimetablesController
{
    Task<CreateResult<DoctorTimetablesDateEntity>> CreateAsync(DoctorTimetablesDateEntity entity);
}