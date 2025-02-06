using System.ComponentModel.DataAnnotations;

namespace Presenters;

public class LoginDoctorDto
{
    /// <summary>
    /// Endereço de e-mail do usuário.
    /// </summary>
    [Required(ErrorMessage = "CRM é obrigatório")]
    public string CRM { get; set; }

    /// <summary>
    /// Senha do usuário.
    /// </summary>
    [Required(ErrorMessage = "Senha é obrigatória")]
    public string Password { get; set; }
}
