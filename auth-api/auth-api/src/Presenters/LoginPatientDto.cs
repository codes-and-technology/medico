using System.ComponentModel.DataAnnotations;

namespace Presenters;

public class LoginPatientDto
{
    /// <summary>
    /// Endereço de e-mail do usuário.
    /// </summary>
    //[Required(ErrorMessage = "E-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "O endereço de e-mail é inválido.")]
    public string Email { get; set; }

    //[Required(ErrorMessage = "CPF é obrigatório")]
    public string CPF { get; set; }


    /// <summary>
    /// Senha do usuário.
    /// </summary>
    [Required(ErrorMessage = "Senha é obrigatória")]
    public string Password { get; set; }
}
