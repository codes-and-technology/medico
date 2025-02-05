using Controllers;
using DataBase.SqlServer;
using DataBase.SqlServer.Configurations;
using Gateways.Database;
using Google;
using Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Prometheus;
using Rabbit.Consumer;
using UseCases;

namespace Main;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .Build();

        builder.Services.AddRabbitMq(configuration);

        builder.Services.UseHttpClientMetrics();

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
        
        builder.Services.AddScoped<INotificationDbGateway, NotificationDbGateway>();
        builder.Services.AddScoped<IEmailGateway,EmailGateway>();
        
        builder.Services.AddScoped<INotificationController, NotificationController>();
        builder.Services.AddScoped<INotificationUseCase, NotificationUseCase>();
        builder.Services.AddScoped<IEmail, Email>();
        
        builder.Services.AddHostedService<Worker>();

        builder.Services.AddDbContext<ApplicationDbContext>(
            options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"));
            }, ServiceLifetime.Scoped);

        builder.Services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy());

        var host = builder.Build();

        host.UseMetricServer();
        host.UseHttpMetrics(options =>
        {
            options.AddCustomLabel("host", context => context.Request.Host.Host);
        });

        host.MapHealthChecks("/health");
        host.MapHealthChecks("/readiness");

        host.Run();
    }
}