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
public class AppointmentsController(IController controller) : ControllerBase
{
    [HttpGet("/doctors")]
    [Authorize(Roles = "PATIENT")]
    public async Task<IActionResult> Doctor()
    {
        try
        {
            var result = await controller.ConsultingDoctorAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }        
    }
}
