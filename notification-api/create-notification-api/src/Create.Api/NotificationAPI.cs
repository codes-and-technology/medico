using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Controllers.Create;
using Presenters;

namespace Create.Api;

/// <summary>
/// Controlador para manipulação de contatos.
/// </summary>
[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class NotificationAPI(IController controller) : ControllerBase
{
    [HttpPost]
    //[Authorize(Roles = "DOCTOR")]
    public async Task<IActionResult> Post(NotificationDto notificationDTO)
    {
        try
        {
            var token = Request.Headers["Authorization"].FirstOrDefault();
            var userID = User.FindFirstValue("ID");

            var result = await controller.CreateNotificationAsync(notificationDTO, token, userID);
            return result.Success ? NoContent() : BadRequest(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
