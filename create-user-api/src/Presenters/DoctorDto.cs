using System.ComponentModel.DataAnnotations;

namespace Presenters;

public class DoctorDto: UserDto
{
    /// <summary>
    /// Endereço de e-mail do contato.
    /// </summary>
    [Required(ErrorMessage = "CRM é obrigatório")]
    [MinLength(11, ErrorMessage = "CRM é obrigatório")]
    [MaxLength(11, ErrorMessage = "CRM é obrigatório")]
    public int CrmNumber { get; set; }
}
