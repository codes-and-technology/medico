using System.Security.Claims;
using CreateInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presenters;

namespace Create.Api.Controllers;

/// <summary>
/// Controlador para manipulação de contatos.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DoctorsTimeTablesController(IController controller) : ControllerBase
{
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
            return BadRequest(ex.Message);
        }        
    }
}
