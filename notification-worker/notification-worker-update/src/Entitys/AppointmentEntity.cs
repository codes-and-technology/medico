using System.ComponentModel.DataAnnotations;

namespace Entitys;

public class AppointmentEntity : EntityBase
{
    public AppointmentEntity()
    {

    }

    public AppointmentEntity(string idPatient, string idDoctor, string idTimetablesDate, string idTimetablesTime)
    {
        IdPatient = idPatient;
        IdDoctor = idDoctor;
        IdDoctorTimetablesDate = idTimetablesDate;
        IdDoctorTimetablesTime = idTimetablesTime;
    }

    [Required(ErrorMessage = "O ID do paciente é obrigatório.")]
    public string IdPatient { get; set; }

    [Required(ErrorMessage = "O ID do médico é obrigatório.")]
    public string IdDoctor { get; set; }

    [Required(ErrorMessage = "O ID da agenda(data) é obrigatório.")]
    public string IdDoctorTimetablesDate { get; set; }

    [Required(ErrorMessage = "O ID da agenda(horario) é obrigatório.")]
    public string IdDoctorTimetablesTime { get; set; }

    public ICollection<NotificationEntity> Notifications { get; set; } = [];
    public UserEntity Pacient { get; set; }
    public UserEntity Doctor { get; set; }
    public DoctorsTimetablesDateEntity TimetablesDate { get; set; }
    public DoctorsTimetablesTimesEntity TimetablesTimes { get; set; }

}
