using DeleteEntitys;
using DeleteInterface;
using DeleteUseCases;
using Presenters;

namespace DeleteController;

public class DeleteDoctorController(
    IDoctorTimetablesQueueGateway doctorTimetablesQueueGateway)
    : IController
{
    public async Task<ResultDto<List<DoctorTimetablesTimeEntity>>> DeleteDoctorAsync(
        DeleteDoctorTimetablesDto deleteDoctorTimetablesDto,
        string token, string doctorId)
    {
        var useCase = new DeleteUseCase(deleteDoctorTimetablesDto);

        var doctorTimetablesTime = useCase.DeleteDoctorTimetablesTime();

        if (!doctorTimetablesTime.Success)
            return doctorTimetablesTime;

        var entity = useCase.DeleteEntity(doctorId, deleteDoctorTimetablesDto.Id, doctorTimetablesTime.Data);

        await doctorTimetablesQueueGateway.SendMessage(entity.Data);
        return doctorTimetablesTime;
    }
}