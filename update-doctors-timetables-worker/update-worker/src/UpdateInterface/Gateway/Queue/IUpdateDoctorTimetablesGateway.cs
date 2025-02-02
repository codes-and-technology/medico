using Presenters;
using UpdateEntitys;

namespace UpdateInterface.Gateway.Queue;

public interface IUpdateDoctorTimetablesGateway
{
    Task<UpdateResult<DoctorTimetablesDateEntity>> UpdateAsync(DoctorTimetablesDateEntity entity);
}