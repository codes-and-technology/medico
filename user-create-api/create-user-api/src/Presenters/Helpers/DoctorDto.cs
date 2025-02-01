using System.ComponentModel.DataAnnotations;

namespace Presenters;

public class DoctorDto : UserDto
{
    /// <summary>
    /// nome do usuário.
    /// </summary>
    [Required(ErrorMessage = "CRM é obrigatório")]
    [MinLength(3, ErrorMessage = "Informe o CRM")]
    [MaxLength(20, ErrorMessage = "Informe o CRM")]
    public string CRM { get; set; }
}