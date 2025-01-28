using Presenters;
using CreateInterface;
using Microsoft.AspNetCore.Mvc;
using Presenters.Enum;

namespace Create.Api.Controllers;

/// <summary>
/// Controlador para manipulação de contatos.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CreateController : ControllerBase
{
    private readonly IController _controller;

    public CreateController(IController controller)
    {
        _controller = controller;
    }

    [HttpPost("/doctor")]
    public async Task<IActionResult> Doctor([FromBody] DoctorDto doctorDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _controller.CreateUserAsync(doctorDto, UserType.Doctor, doctorDto.CrmNumber);
            return result.Success ? NoContent() : BadRequest(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }        
    }

    [HttpPost("/patient")]
    public async Task<IActionResult> Patient([FromBody] Patient patientDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _controller.CreateUserAsync(patientDto, UserType.Patient, null);
            return result.Success ? NoContent() : BadRequest(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
