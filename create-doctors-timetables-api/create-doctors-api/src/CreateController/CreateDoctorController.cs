using CreateEntitys;
using CreateInterface;
using CreateUseCases;
using Presenters;

namespace CreateController;

public class CreateDoctorController(IDoctorTimetablesConsultingGateway doctorTimetablesConsultingGateway, IDoctorTimetablesQueueGateway doctorTimetablesQueueGateway)
    : IController
{
    public async Task<ResultDto<DoctorTimetablesDateEntity>> CreateDoctorAsync(CreateDoctorTimetablesDto createDoctorTimetablesDto,
        string token, string doctorId)
    {
        var result = new ResultDto<List<DoctorTimetablesDateEntity>>();

        var doctoTimetables = await doctorTimetablesConsultingGateway.GetAllAsync(token);

        var useCase = new CreateUseCase(createDoctorTimetablesDto, doctoTimetables, doctorId);

        var doctorTimetablesDate = useCase.CreateDoctorTimetablesDate();

        if (!doctorTimetablesDate.Success)
            return doctorTimetablesDate;

        var doctorTimetablesTime = useCase.CreateDoctorTimetablesTime();
        
        var entity = useCase.CreateEntity(doctorTimetablesDate.Data, doctorTimetablesTime.Data);

        await doctorTimetablesQueueGateway.SendMessage(entity.Data);
        return doctorTimetablesDate;
    }
}