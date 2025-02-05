using System.Text;
using Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Presenters;

namespace Google;

public class Email(IConfiguration configuration) : IEmail
{
    public async Task<Result<MimeMessage>> SendAsync(CreatedAppointmentDto notification)
    {
        var result = new Result<MimeMessage>();
        try
        {
            var email = configuration["EmailSettings:Email"];
            var secret = configuration["EmailSettings:Secret"];
            var domain = configuration["EmailSettings:Domain"];

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Health&Med", email));
            message.To.Add(new MailboxAddress(notification.DoctorName, notification.DoctorEmail));
            message.Subject = "Health&Med - Nova consulta agendada";


            var emailMessage = new StringBuilder();

            emailMessage.Append($"<h2>Olá, Dr. {notification.DoctorName}!</h2>");
            emailMessage.Append($"<p>Você tem uma nova consulta marcada! Paciente: {notification.PatientName}.</p>");
            emailMessage.Append($"<p>Data e horário: {notification.AppointmentDate}.</p>");

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = emailMessage.ToString(),
                TextBody =
                    $"Olá, Dr. {notification.DoctorName} Você tem uma nova consulta marcada! Paciente: {notification.PatientName}. Data e horário: {notification.AppointmentDate}."
            };

            message.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();
            await client.ConnectAsync(domain, 587, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(email, secret);

            await client.SendAsync(message);
            await client.DisconnectAsync(true);

            result.Data = message;
        }
        catch (Exception ex)
        {
            result.Errors.Add(ex.Message);
        }
        
        return result;
    }
}