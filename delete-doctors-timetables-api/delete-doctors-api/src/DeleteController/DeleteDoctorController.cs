using DeleteEntitys;
using DeleteInterface;
using DeleteUseCases;
using Presenters;

namespace DeleteController;

public class DeleteDoctorController(
    IDoctorTimetablesConsultingGateway doctorTimetablesConsultingGateway,
    IDoctorTimetablesQueueGateway doctorTimetablesQueueGateway)
    : IController
{
    public async Task<ResultDto<List<DoctorTimetablesTimeEntity>>> DeleteDoctorAsync(
        DeleteDoctorTimetablesDto deleteDoctorTimetablesDto,
        string token, string doctorId)
    {
        var result = new ResultDto<List<DoctorTimetablesTimeEntity>>();

        var doctoTimetablesList = await doctorTimetablesConsultingGateway.GetAllAsync(token);

        var useCase = new DeleteUseCase(deleteDoctorTimetablesDto, doctoTimetablesList);

        var doctorTimetablesTime = useCase.DeleteDoctorTimetablesTime();

        if (!doctorTimetablesTime.Success)
            return doctorTimetablesTime;

        var entity = useCase.DeleteEntity(doctorId, deleteDoctorTimetablesDto.Id, doctorTimetablesTime.Data);

        await doctorTimetablesQueueGateway.SendMessage(entity.Data);
        return result;
    }
}