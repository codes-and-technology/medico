using System.Security.Claims;
using DeleteInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presenters;

namespace Delete.Api.Controllers;

/// <summary>
/// Controlador responsável pela gestão e atualização de horários de médicos.
/// Apenas usuários com a função "DOCTOR" podem excluir horários.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DoctorsTimeTablesController(IController controller) : ControllerBase
{
    /// <summary>
    /// Exclui horários cadastrados por um médico.
    /// </summary>
    /// <param name="deleteDoctorTimetablesDto">Objeto contendo os horários a serem removidos.</param>
    /// <returns>204 No Content se bem-sucedido, ou 400 Bad Request em caso de erro.</returns>
    /// <remarks>
    /// Somente usuários com a função "DOCTOR" podem realizar esta ação.
    /// </remarks>
    [HttpDelete]
    [Authorize(Roles = "DOCTOR")]
    public async Task<IActionResult> Delete(DeleteDoctorTimetablesDto deleteDoctorTimetablesDto)
    {
        try
        {
            var token = Request.Headers["Authorization"].FirstOrDefault();
            var doctorId = User.FindFirstValue("ID");

            var result = await controller.DeleteDoctorAsync(deleteDoctorTimetablesDto, token, doctorId);
            return result.Success ? NoContent() : BadRequest(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
