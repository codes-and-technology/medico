using Interfaces;
using MimeKit;
using Presenters;

namespace Gateways.Database;

public class EmailGateway(IEmail email) : IEmailGateway
{
    public async Task<Result<MimeMessage>> NotificationAsync(CreatedAppointmentDto notification) =>  await email.SendAsync(notification);
    
}