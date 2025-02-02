using System.ComponentModel.DataAnnotations;
namespace CreateEntitys;

public class PendingNotificationEntity : NotificationEntity
{
    [Required]
    public string DoctorEmail { get; set; }
    public string DoctorName { get; set; }
    public string PatientName { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string AppointmentTime { get; set; }

}