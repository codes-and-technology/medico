using System;
using System.Diagnostics;
using DataBase;
using DataBase.SqlServer;
using Microsoft.EntityFrameworkCore;
using CreateEntitys;
using GMail;

namespace Create.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Worker(IServiceProvider serviceProvider, ILogger<Worker> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Notification Worker iniciado...");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    if (_logger.IsEnabled(LogLevel.Information))
                    {
                        _logger.LogInformation("Notification Worker running at: {time}", DateTimeOffset.Now);

                        ApplicationDbContext dbContext = _serviceProvider.GetRequiredService<ApplicationDbContext>();
                        var pendingNotifications = await dbContext.PendingNotifications.ToListAsync();

                        SimpleGMail gMail = new SimpleGMail();
                        String strGmailErr = "";

                        foreach (var notification in pendingNotifications)
                        {
                            SimpleGMail sgMail = new SimpleGMail();

                            if (sgMail.Send("kevans.br@gmail.com", "Teste de envio de email", "Conteudo do envio de email", ref strGmailErr))
                            {
                                _logger.LogInformation($"Email enviado com sucesso para a notificação");
                                notification.Success = true;
                                notification.SendDate = DateTime.UtcNow;
                            }
                            else
                            {
                                _logger.LogError($"Erro ao enviar e-mail para: {strGmailErr}");
                                notification.Success = false;
                                notification.ErrorMessage = strGmailErr;
                            }
                        }

                        await dbContext.SaveChangesAsync(stoppingToken);
                    }

                }
                catch(Exception e)
                {
                    _logger.LogError("Deu erro mano");
                    Console.WriteLine("Deu erro mano");
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
