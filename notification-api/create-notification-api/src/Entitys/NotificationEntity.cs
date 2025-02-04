using System.ComponentModel.DataAnnotations;

namespace Entitys
{
    public class NotificationEntity : EntityBase
    {
        public NotificationEntity()
        {

        }

        public NotificationEntity(string idAppointment, DateTime sendDate, string message, bool success, string errorMessage)
        {
            IdAppointment = idAppointment;
            SendDate = sendDate;
            Message = message;
            Success = success;
            ErrorMessage = errorMessage;
        }

        [Required(ErrorMessage = "O ID do compromisso é obrigatório.")]
        public string IdAppointment { get; set; } 
        public DateTime SendDate { get; set; }

        [Required(ErrorMessage = "A mensagem é obrigatório.")]
        public string Message { get; set; } 
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

        public AppointmentEntity Appointment { get; set; }

        public override string ToString()
        {
            return $"IdAppointment: {IdAppointment}, SendDate: {SendDate}, Message: {Message}, Success: {Success}, ErrorMessage: {ErrorMessage}";
        }

        /*
        public static implicit operator NotificationEntity(NotificationEntity v)
        {
            throw new NotImplementedException();
        }
        */
    }
}
