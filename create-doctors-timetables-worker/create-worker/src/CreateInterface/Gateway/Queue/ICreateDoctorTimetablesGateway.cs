using Presenters;
using CreateEntitys;

namespace CreateInterface.Gateway.Queue;

public interface ICreateDoctorTimetablesGateway
{
    Task<CreateResult<DoctorTimetablesDateEntity>> CreateAsync(DoctorTimetablesDateEntity entity);
}