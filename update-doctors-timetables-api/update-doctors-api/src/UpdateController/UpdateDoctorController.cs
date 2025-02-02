using UpdateEntitys;
using UpdateInterface;
using UpdateUseCases;
using Presenters;

namespace UpdateController;

public class UpdateDoctorController(
    IDoctorTimetablesConsultingGateway doctorTimetablesConsultingGateway,
    IDoctorTimetablesQueueGateway doctorTimetablesQueueGateway)
    : IController
{
    public async Task<ResultDto<List<DoctorTimetablesTimeEntity>>> UpdateDoctorAsync(
        UpdateDoctorTimetablesDto updateDoctorTimetablesDto,
        string token, string doctorId)
    {
        var result = new ResultDto<List<DoctorTimetablesTimeEntity>>();

        var doctoTimetablesList = await doctorTimetablesConsultingGateway.GetAllAsync(token);

        var useCase = new UpdateUseCase(updateDoctorTimetablesDto, doctoTimetablesList, doctorId);

        var doctorTimetablesTime = useCase.UpdateDoctorTimetablesTime();

        if (!doctorTimetablesTime.Success)
            return doctorTimetablesTime;

        var entity = useCase.UpdateEntity(updateDoctorTimetablesDto.Id, doctorId, doctorTimetablesTime.Data);

        await doctorTimetablesQueueGateway.SendMessage(entity.Data);
        return result;
    }
}