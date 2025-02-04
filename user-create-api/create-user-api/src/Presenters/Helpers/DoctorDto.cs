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

    [Required(ErrorMessage = "Valor é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Valor deve ser maior que zero.")]
    public decimal Amount { get; set; }

    /// <summary>
    /// Especialidade
    /// </summary>
    [Required(ErrorMessage = "Especialidade é obrigatório")]
    [MinLength(3, ErrorMessage = "Mínimo 3 caracteres")]
    [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
    public string Specialty { get; set; }

    /// <summary>
    /// Avaliação do médico
    /// </summary>
    [Required(ErrorMessage = "A Avaliação é obrigatória.")]
    [Range(1, 5, ErrorMessage = "A Avaliação deve estar entre 1 e 5.")]
    public int Score { get; set; }
}
