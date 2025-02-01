using System.ComponentModel.DataAnnotations;
namespace CreateEntitys;

public class NotificationEntity : EntityBase
{
    [Required]
    public string Message { get; set; }
    public DateTime? SendDate { get; set; }
    public bool? Sucess { get; set; }
    public string? ErrorMessage { get; set; }
}