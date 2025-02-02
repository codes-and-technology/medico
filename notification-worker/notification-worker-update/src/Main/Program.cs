using DataBase.SqlServer;
using DataBase.SqlServer.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Prometheus;
using Rabbit.Consumer.Update;
using Redis;
using Update.Worker;
using Controllers.Update;
using Gateways.Cache;
using Gateways.Queue;
using Gateways.Database;
using UseCases.Update;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configuração: Carregar appsettings e arquivos específicos para o ambiente
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .Build();

        builder.Services.AddRabbitMq(configuration);
        builder.Services.AddRedis(configuration);

        builder.Services.UseHttpClientMetrics();

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        //builder.Services.AddScoped<IContactRepository, ContactRepository>();
        //builder.Services.AddScoped<IPhoneRegionRepository, PhoneRegionRepository>();
        builder.Services.AddScoped<INotificationRepository, NotificationRepository>();

        //builder.Services.AddScoped<IContactDBGateway, ContactDBGateway>();
        //builder.Services.AddScoped<IPhoneRegionDBGateway, PhoneRegionDBGateway>();
        builder.Services.AddScoped<INotificationDBGateway, NotificationDBGateway>();

        builder.Services.AddScoped(typeof(ICacheGateway<>), typeof(CacheGateway<>));

        //builder.Services.AddScoped<IUpdateContactGateway, UpdateContactGateway>();
        //builder.Services.AddScoped<IUpdateContactController, UpdateContactController>();
        //builder.Services.AddScoped<IUpdateContactUseCase, UpdateContactUseCase>();

        builder.Services.AddScoped<IUpdateNotificationGateway, UpdateNotificationGateway>();
        builder.Services.AddScoped<IUpdateNotificationController, UpdateNotificationController>();
        builder.Services.AddScoped<IUpdateNotificationUseCase, UpdateNotificationUseCase>();

        builder.Services.AddHostedService<Worker>();

        // Configuração do DbContext
        builder.Services.AddDbContext<ApplicationDbContext>(
            options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"));
            }, ServiceLifetime.Scoped);

        // Adiciona health checks
        builder.Services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy());

        var host = builder.Build();

        /* INICIO DA CONFIGURAÇÃO - PROMETHEUS */
        host.UseMetricServer();
        host.UseHttpMetrics(options =>
        {
            options.AddCustomLabel("host", context => context.Request.Host.Host);
        });
        /* FIM DA CONFIGURAÇÃO - PROMETHEUS */

        // Configura os endpoints de health check
        host.MapHealthChecks("/health");
        host.MapHealthChecks("/readiness");

        host.Run();
    }
}