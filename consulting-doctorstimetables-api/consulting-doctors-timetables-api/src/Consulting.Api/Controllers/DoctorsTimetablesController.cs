using ConsultingInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Consulting.Api.Controllers;

/// <summary>
/// Controlador responsável pelo gerenciamento da agenda médica.
/// Permite a consulta de horários disponíveis de médicos.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DoctorsTimetablesController(IController controller) : ControllerBase
{
    /// <summary>
    /// Obtém os horários cadastrados pelo médico autenticado.
    /// </summary>
    /// <returns>200 OK com a lista de horários, 400 Bad Request em caso de erro ou 401 Unauthorized se o usuário não for identificado.</returns>
    /// <remarks>
    /// Somente usuários com a função "DOCTOR" podem acessar este endpoint.
    /// </remarks>
    [HttpGet("/doctors-timetables")]
    [Authorize(Roles = "DOCTOR")]
    public async Task<IActionResult> Doctor()
    {
        try
        {
            var userId = User.FindFirst("ID")?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID not found in token.");
            }

            var result = await controller.ConsultingDoctorsTimetablesDateAsync(userId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
