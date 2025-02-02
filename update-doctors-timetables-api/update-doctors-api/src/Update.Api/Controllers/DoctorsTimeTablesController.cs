using System.Security.Claims;
using UpdateInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presenters;

namespace Update.Api.Controllers;

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
    public async Task<IActionResult> Put(UpdateDoctorTimetablesDto updateDoctorTimetablesDto)
    {
        try
        {
            var token = Request.Headers["Authorization"].FirstOrDefault();
            var doctorId = User.FindFirstValue("ID"); 

            var result = await controller.UpdateDoctorAsync(updateDoctorTimetablesDto, token, doctorId);
            return result.Success ? NoContent() : BadRequest(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }        
    }
}
