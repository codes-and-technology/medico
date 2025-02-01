using ConsultingInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Consulting.Api.Controllers;

/// <summary>
/// Controlador para manipulação de contatos.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DoctorsTimetablesController(IController controller) : ControllerBase
{
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
            return BadRequest(ex.Message);
        }
    }
}
