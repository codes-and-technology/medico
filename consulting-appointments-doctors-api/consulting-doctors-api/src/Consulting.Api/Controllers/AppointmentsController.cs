﻿using ConsultingInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Consulting.Api.Controllers;

/// <summary>
/// Controlador para manipulação de contatos.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AppointmentsController(IDoctorController doctorController, IDoctorTimetablesController doctorTimetablesController) : ControllerBase
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
    public async Task<IActionResult> Timetables()
    {
        try
        {
            var userId = User.FindFirst("ID")?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID not found in token.");
            }

            var result = await doctorTimetablesController.ConsultingTimetablesAsync(userId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
