namespace Presenters;

public class NotificationDto
{

    public Guid Id { get; set; }
    public string IdAppointments { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? SendDate { get; set; }
    public string Message { get; set; }
    public bool? Success { get; set; }
    public string ErrorMessage { get; set; }
}