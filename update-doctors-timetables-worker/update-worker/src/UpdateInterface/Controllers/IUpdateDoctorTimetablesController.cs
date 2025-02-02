using UpdateEntitys;
using Presenters;

namespace UpdateInterface.Controllers;

public interface IUpdateDoctorTimetablesController
{
    Task<UpdateResult<DoctorTimetablesDateEntity>> UpdateAsync(DoctorTimetablesDateEntity entity);
}