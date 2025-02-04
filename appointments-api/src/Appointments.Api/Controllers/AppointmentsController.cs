using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presenters;
using System.Security.Claims;

namespace Consulting.Api.Controllers;

/// <summary>
/// Controlador para manipulação de contatos.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AppointmentsController(IDoctorController doctorController, IDoctorTimetablesController doctorTimetablesController, IAppointmentController appointmentController) : ControllerBase
{
    [HttpGet("/doctors")]
    [Authorize(Roles = "PATIENT")]
    public async Task<IActionResult> Doctor()
    {
        try
        {
            var result = await doctorController.ConsultingDoctorAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }        
    }

    [HttpGet("/timetables")]
    [Authorize(Roles = "PATIENT")]
    public async Task<IActionResult> Timetables(string idDoctor)
    {
        try
        {
            var result = await doctorTimetablesController.ConsultingTimetablesAsync(idDoctor);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Authorize(Roles = "PATIENT")]
    public async Task<IActionResult> Create(CreateAppointmentDto dto)
    {
        try
        {
            string idUser = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await appointmentController.CreateAppointmentAsync(idUser, dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
