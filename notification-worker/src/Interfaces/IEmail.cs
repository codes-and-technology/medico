using MimeKit;
using Presenters;

namespace Interfaces;

public interface IEmail
{
    Task<Result<MimeMessage>> SendAsync(CreatedAppointmentDto notification);
}