namespace Entitys;

public class NotificationEntity : EntityBase
{
    public NotificationEntity()
    {
    }

    public NotificationEntity(string idAppointment, DateTime sendDate, string message, bool success,
        string errorMessage)
    {
        Id = idAppointment;
        SendDate = sendDate;
        Message = message;
        Success = success;
        ErrorMessage = errorMessage;
    }

    public string IdAppointments { get; set; }
    public DateTime SendDate { get; set; }

    public string Message { get; set; }
    public bool Success { get; set; }
    public string ErrorMessage { get; set; }

    public override string ToString()
    {
        return
            $"IdAppointment: {IdAppointments}, SendDate: {SendDate}, Message: {Message}, Success: {Success}, ErrorMessage: {ErrorMessage}";
    }
}