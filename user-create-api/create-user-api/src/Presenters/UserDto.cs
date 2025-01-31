using System.ComponentModel.DataAnnotations;

namespace Presenters;

public class UserDto
{
    /// <summary>
    /// nome do usuário.
    /// </summary>
    [Required(ErrorMessage = "O nome do é obrigatório.")]
    [MinLength(10, ErrorMessage = "O nome do usuário não pode ter menos de 10 caracteres.")]
    [MaxLength(250, ErrorMessage = "O nome do usuário não pode ter mais de 250 caracteres.")]
    public string Name { get; set; }

    /// <summary>
    /// CPF
    /// </summary>
    [Required(ErrorMessage = "CPF é obrigatório")]
    [MinLength(11, ErrorMessage = "CPF é obrigatório")]
    [MaxLength(11, ErrorMessage = "CPF é obrigatório")]
    public string DocumentNumber { get; set; }

    /// <summary>
    /// Endereço de e-mail do contato.
    /// </summary>
    [EmailAddress(ErrorMessage = "O endereço de e-mail é inválido.")]
    public string Email { get; set; }


    public string Password { get; set; }
    
}
