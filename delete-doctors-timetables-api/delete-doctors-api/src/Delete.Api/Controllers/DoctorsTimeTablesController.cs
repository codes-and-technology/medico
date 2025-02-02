using System.Security.Claims;
using DeleteInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presenters;

namespace Delete.Api.Controllers;

/// <summary>
/// Controlador para atualização de horários
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DoctorsTimeTablesController(IController controller) : ControllerBase
{
    [HttpPut]
    [Authorize(Roles = "DOCTOR")]
    public async Task<IActionResult> Put(DeleteDoctorTimetablesDto deleteDoctorTimetablesDto)
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
            return BadRequest(ex.Message);
        }        
    }
}
