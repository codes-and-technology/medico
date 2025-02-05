using MimeKit;
using Presenters;

namespace Interfaces
{
    public interface IEmailGateway
    {
        Task<Result<MimeMessage>> NotificationAsync(CreatedAppointmentDto notification);
    }
}
