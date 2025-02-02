using Presenters;
using DeleteEntitys;

namespace DeleteInterface.Gateway.Queue;

public interface IDeleteDoctorTimetablesGateway
{
    Task<DeleteResult<DoctorTimetablesDateEntity>> DeleteAsync(DoctorTimetablesDateEntity entity);
}