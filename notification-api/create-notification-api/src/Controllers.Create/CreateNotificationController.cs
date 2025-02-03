using Entitys;
using UseCases.Create;
using Presenters;
using Gateways.External;

namespace Controllers.Create;

public class CreateNotificationController(INotificationGateway notificationGateway): IController
{
    public async Task<ResultDto<NotificationEntity>> CreateNotificationAsync(NotificationDto notificationDTO, string token, string userID)
    {
        var result = new ResultDto<NotificationEntity>();

        var useCase = new CreateNotificationUseCase(notificationDTO);
        

        //var useCase = new CreateNotificationUseCase(createDoctorTimetablesDto, doctoTimetables, doctorId);

        //var doctorTimetablesDate = useCase.CreateDoctorTimetablesDate();

        //if (!doctorTimetablesDate.Success)
        //    return doctorTimetablesDate;

        //var doctorTimetablesTime = useCase.CreateDoctorTimetablesTime();

        //var entity = useCase.CreateEntity(doctorTimetablesDate.Data, doctorTimetablesTime.Data);

        //await doctorTimetablesQueueGateway.SendMessage(entity.Data);
        //return doctorTimetablesDate;

        return result;
    }
}