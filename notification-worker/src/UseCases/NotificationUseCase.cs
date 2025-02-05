using Presenters;
using Entitys;
using Interfaces;
using MimeKit;

namespace UseCases;

public class NotificationUseCase() : INotificationUseCase
{
    public Result<CreatedAppointmentDto> Notification(CreatedAppointmentDto dto)
    {
        var result = new Result<CreatedAppointmentDto>();

        if (dto is null || 
            string.IsNullOrEmpty(dto.Id) ||
            string.IsNullOrEmpty(dto.DoctorEmail) ||
            string.IsNullOrEmpty(dto.DoctorName) ||
            string.IsNullOrEmpty(dto.PatientName) ||
            string.IsNullOrEmpty(dto.AppointmentDate))
        {
             result.Errors.Add("Objeto inválido não é possível enviar um email pois falta informações");
             return result;
        }

        result.Data = dto;
        return result;
    }

    public Result<NotificationEntity> CreateEntity(Result<MimeMessage> emailResult, string id)
    {
        var result = new Result<NotificationEntity>();
        var entity = new NotificationEntity();
        entity.Id = Guid.NewGuid().ToString();
        entity.Message = emailResult.Success ? emailResult.Data.TextBody : string.Empty;
        entity.Success = emailResult.Success;
        entity.SendDate = DateTime.Now;
        entity.IdAppointments = id;

        if (!emailResult.Success)
            entity.ErrorMessage = emailResult.Errors[0];
        
        result.Data =  entity;
        return result;
    }
}
