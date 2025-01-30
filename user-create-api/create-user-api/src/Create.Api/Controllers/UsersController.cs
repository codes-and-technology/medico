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
public class UsersController(IController controller) : ControllerBase
{
    [HttpPost("/doctor")]
    public async Task<IActionResult> Doctor([FromBody] UserDto userDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await controller.CreateUserAsync(userDto);
            return result.Success ? NoContent() : BadRequest(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }        
    }

    [HttpPost("/patient")]
    public async Task<IActionResult> Patient([FromBody] UserDto userDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await controller.CreateUserAsync(userDto);
            return result.Success ? NoContent() : BadRequest(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
