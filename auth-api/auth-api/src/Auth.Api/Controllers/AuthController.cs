using AuthInterface;
using Microsoft.AspNetCore.Mvc;
using Presenters;

namespace Auth.Api.Controllers;

/// <summary>
/// Controlador para manipulação de usuários
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AuthController(IController controller) : ControllerBase
{
    /// <summary>
    /// Método para autenticação de usuários
    /// </summary>
    /// <param name="login">Dados do login</param>
    /// <returns></returns>
    [HttpPost("/auth/doctor")]
    public async Task<IActionResult> AuthDoctor([FromBody] LoginDoctorDto login)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await controller.AuthAsync(login);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Método para autenticação de usuários
    /// </summary>
    /// <param name="login">Dados do login</param>
    /// <returns></returns>
    [HttpPost("/auth/patient")]
    public async Task<IActionResult> AuthPatient([FromBody] LoginPatientDto login)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await controller.AuthAsync(login);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
