using DeleteEntitys;
using Presenters;

namespace DeleteInterface.Controllers;

public interface IDeleteDoctorTimetablesController
{
    Task<DeleteResult<DoctorTimetablesDateEntity>> DeleteAsync(DoctorTimetablesDateEntity entity);
}