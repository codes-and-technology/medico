using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presenters;
using System.ComponentModel.DataAnnotations;
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

    /// <summary>
    /// Confirma ou rejeita um agendamento.
    /// </summary>
    /// <param name="idAppointment">ID do agendamento.</param>
    /// <param name="isConfirmed">Indica se o agendamento está confirmado (true) ou rejeitado (false).</param>
    /// <returns>Resultado da confirmação do agendamento.</returns>
    [HttpPost("/Confirm")]
    [Authorize(Roles = "DOCTOR")]
    [ProducesResponseType(typeof(ResultDto<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultDto<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Confirm([Required] string idAppointment, [Required] bool isConfirmed)
    {
        try
        {
            var result = await appointmentController.ConfirmAsync(idAppointment, isConfirmed);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Consulta os detalhes de um agendamento para o paciente logado.
    /// </summary>
    /// <returns>Detalhes do agendamento.</returns>
    [HttpGet("/Appointment")]
    [Authorize(Roles = "PATIENT")]
    [ProducesResponseType(typeof(ResultDto<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultDto<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Appointment()
    {
        try
        {
            string idUser = User.FindFirstValue("Id");

            var result = await appointmentController.ConsultAppointment(idUser);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Paciente Cancelar Agendamento
    /// </summary>
    /// <param name="idAppointment">ID do agendamento.</param>
    /// <returns>Resultado do cancelamento</returns>
    [HttpDelete("/Appointment/{idAppointment}")]
    [Authorize(Roles = "PATIENT")]
    [ProducesResponseType(typeof(ResultDto<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultDto<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteAppointment(string idAppointment)
    {
        try
        {
            string idUser = User.FindFirstValue("Id");

            var result = await appointmentController.DeleteAppointment(idAppointment, idUser);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
}
