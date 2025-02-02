using DeleteEntitys;
using DeleteInterface.Controllers;
using DeleteInterface.Gateway.Queue;
using Presenters;

namespace QueueGateways
{
    public class DeleteDoctorTimetablesGateway(IDeleteDoctorTimetablesController deleteDoctorTimetablesController) : IDeleteDoctorTimetablesGateway
    {
        public async Task<DeleteResult<DoctorTimetablesDateEntity>> DeleteAsync(DoctorTimetablesDateEntity entity) 
            => await deleteDoctorTimetablesController.DeleteAsync(entity);
    }
}
