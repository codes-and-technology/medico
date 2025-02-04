using Entitys;
using Presenters;

namespace Controllers.Create;

public interface IController
{
    //Task<ResultDto<DoctorTimetablesDateEntity>> CreateDoctorAsync(CreateDoctorTimetablesDto createDoctorTimetablesDto, string token, string doctorId);
    Task<ResultDto<NotificationEntity>> CreateNotificationAsync(NotificationDto notificationDTO, string token, string userID);

}