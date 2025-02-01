using System;

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
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Notification Worker running at: {time}", DateTimeOffset.Now);

                    /*
                    var scope = _serviceProvider.CreateScope();
                    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    var pendingNotifications = await dbContext.ToListAsync(stoppingToken);

                    foreach (var notification in pendingNotifications)
                    {
                        try
                        {
                            //EnviaEmail(notification);
                            notification.SendDate = DateTime.UtcNow;
                            notification.Success = true;
                            _logger.LogInformation($"Email enviado com sucesso para a notificação {notification.Id}");
                        }
                        catch (Exception ex)
                        {
                            notification.Success = false;
                            notification.ErrorMessage = ex.Message;
                            _logger.LogError($"Erro ao enviar e-mail para {notification.Id}: {ex.Message}");
                        }
                    }
                    */

                }
                
                await Task.Delay(TimeSpan.FromMinutes(2), stoppingToken);
            }
        }
    }
}
