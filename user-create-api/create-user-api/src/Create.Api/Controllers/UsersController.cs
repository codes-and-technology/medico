using Presenters;
using CreateInterface;
using Microsoft.AspNetCore.Mvc;

namespace Create.Api.Controllers;

/// <summary>
/// Controlador para manipulação de contatos.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class UsersController(IController controller) : ControllerBase
{
    /// <summary>
    /// Cria um novo usuário do tipo médico.
    /// </summary>
    /// <param name="doctorDto">Dados do médico a ser cadastrado.</param>
    /// <returns>204 No Content se bem-sucedido, ou 400 Bad Request em caso de erro.</returns>
    [HttpPost("doctor")]
    public async Task<IActionResult> CreateDoctor([FromBody] DoctorDto doctorDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var result = await controller.CreateUserAsync(
                doctorDto, doctorDto.CRM, doctorDto.Amount, doctorDto.Specialty, doctorDto.Score
            );

            return result.Success ? NoContent() : BadRequest(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Cria um novo usuário do tipo paciente.
    /// </summary>
    /// <param name="patientDto">Dados do paciente a ser cadastrado.</param>
    /// <returns>204 No Content se bem-sucedido, ou 400 Bad Request em caso de erro.</returns>
    [HttpPost("patient")]
    public async Task<IActionResult> CreatePatient([FromBody] PatientDto patientDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var result = await controller.CreateUserAsync(patientDto, string.Empty, null, string.Empty, null);

            return result.Success ? NoContent() : BadRequest(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
