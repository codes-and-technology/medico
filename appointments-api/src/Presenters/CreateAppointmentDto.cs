using System.ComponentModel.DataAnnotations;

namespace Presenters;

public class CreateAppointmentDto
{
    [Required(ErrorMessage = "O id do médico deve ser informado")]
    public string IdDoctor { get; set; }

    [Required(ErrorMessage = "O id da data do agendamento deve ser informado")]
    public string IdDoctorsTimetablesDate { get; set; }

    [Required(ErrorMessage = "O id da hora do agendamento deve ser informado")]
    public string IdDoctorsTimetablesTime { get; set; }
}
