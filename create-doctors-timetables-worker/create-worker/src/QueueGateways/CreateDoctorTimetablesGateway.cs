using CreateEntitys;
using CreateInterface.Controllers;
using CreateInterface.Gateway.Queue;
using Presenters;

namespace QueueGateways
{
    public class CreateDoctorTimetablesGateway(ICreateDoctorTimetablesController createDoctorTimetablesController) : ICreateDoctorTimetablesGateway
    {
        public async Task<CreateResult<DoctorTimetablesDateEntity>> CreateAsync(DoctorTimetablesDateEntity entity) => await createDoctorTimetablesController.CreateAsync(entity);
    }
}
