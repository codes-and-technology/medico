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
    /// <summary>
    /// Consulta os médicos disponíveis.
    /// </summary>
    /// <returns>Lista de médicos.</returns>
    [HttpGet("/doctors")]
    [Authorize(Roles = "PATIENT")]
    [ProducesResponseType(typeof(ResultDto<List<UserDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultDto<List<UserDto>>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Doctor([FromQuery] string specialty, [FromQuery] int? score)
    {
        try
        {
            var result = await doctorController.ConsultingDoctorAsync(specialty, score);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Consulta os horários disponíveis de um médico.
    /// </summary>
    /// <param name="idDoctor">ID do médico.</param>
    /// <returns>Lista de horários disponíveis.</returns>
    [HttpGet("/timetables")]
    [Authorize(Roles = "PATIENT")]
    [ProducesResponseType(typeof(ResultDto<List<DoctorsTimetablesDateDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultDto<List<DoctorsTimetablesDateDto>>), StatusCodes.Status400BadRequest)]
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

    /// <summary>
    /// Cria um novo agendamento.
    /// </summary>
    /// <param name="dto">Dados do agendamento.</param>
    /// <returns>Resultado da criação do agendamento.</returns>
    [HttpPost("/Appointments")]
    [Authorize(Roles = "PATIENT")]
    [ProducesResponseType(typeof(ResultDto<CreatedAppointmentDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultDto<CreatedAppointmentDto>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateAppointmentDto dto)
    {
        try
        {
            string idUser = User.FindFirstValue("Id");

            var result = await appointmentController.CreateAppointmentAsync(idUser, dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
