using UpdateEntitys;
using UpdateInterface.Controllers;
using UpdateInterface.Gateway.Queue;
using Presenters;

namespace QueueGateways
{
    public class UpdateDoctorTimetablesGateway(IUpdateDoctorTimetablesController updateDoctorTimetablesController) : IUpdateDoctorTimetablesGateway
    {
        public async Task<UpdateResult<DoctorTimetablesDateEntity>> UpdateAsync(DoctorTimetablesDateEntity entity) => await updateDoctorTimetablesController.UpdateAsync(entity);
    }
}
