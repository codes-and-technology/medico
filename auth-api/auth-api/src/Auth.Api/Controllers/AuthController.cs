using CreateInterface;
using Microsoft.AspNetCore.Mvc;
using Presenters;

namespace Auth.Api.Controllers;

/// <summary>
/// Controlador para manipulação de usuários
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class UsersController(IController controller) : ControllerBase
{
    /// <summary>
    /// Método para autenticação de usuários
    /// </summary>
    /// <param name="login">Dados do login</param>
    /// <returns></returns>
    [HttpPost("/auth")]
    public async Task<IActionResult> Auth([FromBody] LoginDto login)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await controller.AuthAsync(login);
            return result.Success ? NoContent() : BadRequest(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
