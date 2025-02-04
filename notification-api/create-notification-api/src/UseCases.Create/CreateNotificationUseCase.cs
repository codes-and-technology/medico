using Entitys;
using Presenters;

namespace UseCases.Create;

public class CreateNotificationUseCase(NotificationDto notificationDTO)
{
    public ResultDto<NotificationEntity> CreateNotification()
    {
        var result = new ResultDto<NotificationEntity>();
        result.Data = new NotificationEntity()
        {
            Id = Guid.NewGuid(),
            IdAppointment = notificationDTO.IdAppointment,
            CreateDate = DateTime.Now

        };
       return result;

        /*
        if (doctoTimetablesList is not null 
            && doctoTimetablesList.Date == createDoctorTimetablesDto.AvailableDate.ToString("yyyy-MM-dd")
            && doctoTimetablesList
            .TimeList
            .Any(item =>
                createDoctorTimetablesDto.Times.Contains(item.Time))
            )
        {
            result.Errors.Add("Existe Data e Horário cadastrado no sistema, verifique os dados e tente novamente.");
            return result;
        }
        
        result.Data = new DoctorsTimetablesDateEntity()
        {
            Id = Guid.NewGuid().ToString(),
            CreateDate = DateTime.Now,
            IdDoctor = doctorId,
            AvailableDate = createDoctorTimetablesDto.AvailableDate
        };
        */

    }
    

/*    
    public ResultDto<NotificationEntity> CreateEntity(DoctorTimetablesDateEntity doctorTimetablesDateEntity, List<DoctorTimetablesTimeEntity> doctorTimetablesTimeList)
    {
        var result = new ResultDto<NotificationEntity>
        {
            Data = new NotificationEntity
            {
                DoctorTimetablesTimes = [.. doctorTimetablesTimeList],
                IdDoctor = doctorTimetablesDateEntity.IdDoctor,
                Id = doctorTimetablesDateEntity.Id,
                AvailableDate = doctorTimetablesDateEntity.AvailableDate
            }
        };

        return result;
    }
*/
}
