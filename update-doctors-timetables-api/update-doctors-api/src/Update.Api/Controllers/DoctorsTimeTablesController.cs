using System.Security.Claims;
using UpdateInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presenters;

namespace Update.Api.Controllers;

/// <summary>
/// Controlador responsável pela atualização dos horários dos médicos.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DoctorsTimeTablesController(IController controller) : ControllerBase
{
    /// <summary>
    /// Atualiza os horários de um médico.
    /// </summary>
    /// <param name="updateDoctorTimetablesDto">Objeto contendo os novos horários do médico.</param>
    /// <returns>Retorna NoContent se a atualização for bem-sucedida ou BadRequest em caso de erro.</returns>
    [HttpPut]
    [Authorize(Roles = "DOCTOR")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
