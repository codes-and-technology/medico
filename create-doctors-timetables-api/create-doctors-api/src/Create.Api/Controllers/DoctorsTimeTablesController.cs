using System.Security.Claims;
using CreateInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presenters;

namespace Create.Api.Controllers;

/// <summary>
/// Controlador responsável pelo gerenciamento de horários de médicos.
/// Permite a criação e manipulação da agenda dos profissionais de saúde.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DoctorsTimeTablesController(IController controller) : ControllerBase
{
    /// <summary>
    /// Registra novos horários na agenda do médico.
    /// </summary>
    /// <param name="createDoctorTimetablesDto">Objeto contendo as informações dos horários a serem cadastrados.</param>
    /// <returns>204 No Content se bem-sucedido, ou 400 Bad Request em caso de erro.</returns>
    /// <remarks>
    /// Somente usuários com a função "DOCTOR" podem realizar esta ação.
    /// </remarks>
    [HttpPost]
    [Authorize(Roles = "DOCTOR")]
    public async Task<IActionResult> Post(CreateDoctorTimetablesDto createDoctorTimetablesDto)
    {
        try
        {
            var token = Request.Headers["Authorization"].FirstOrDefault();
            var doctorId = User.FindFirstValue("ID");

            var result = await controller.CreateDoctorAsync(createDoctorTimetablesDto, token, doctorId);
            return result.Success ? NoContent() : BadRequest(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
