using Presenters;

namespace Gateways.External;

public interface INotificationGateway
{
    Task<NotificationDto> GetAllAsync(string token);
}