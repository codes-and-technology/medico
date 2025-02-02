using CacheGateways;
using Delete.Worker;
using DeleteController;
using DeleteEntitys;
using DeleteInterface.Controllers;
using DeleteInterface.DataBase;
using DeleteInterface.Gateway.Cache;
using DeleteInterface.Gateway.DB;
using DeleteInterface.Gateway.Queue;
using DeleteInterface.UseCase;
using DeleteUseCases.UseCase;
using DataBase.SqlServer;
using DataBase.SqlServer.Configurations;
using DBGateways;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Prometheus;
using QueueGateways;
using Rabbit.Consumer.Delete;
using Redis;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configura��o: Carregar appsettings e arquivos espec�ficos para o ambiente
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .Build();

        builder.Services.UseHttpClientMetrics();
        
        builder.Services.AddRabbitMq(configuration);
        builder.Services.AddRedis(configuration);

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped(typeof(ICacheGateway<>), typeof(CacheGateway<>));
        builder.Services.AddScoped<IDeleteDoctorTimetablesGateway, DeleteDoctorTimetablesGateway>();
        builder.Services.AddScoped<IDeleteDoctorTimetablesController, DeleteDoctorTimetablesController>();
        builder.Services.AddScoped<IDeleteDoctorTimetablesUseCase, DeleteDoctorTimetablesUseCase>();
        builder.Services.AddScoped<IDoctorTimetablesDateDBGateway, DoctorTimetablesDateDbGateway>();
        builder.Services.AddScoped<IDoctorTimetablesTimeDBGateway, DoctorTimetablesTimesDbGateway>();
        builder.Services.AddScoped<IDoctorTimetablesDateRepository, DoctorTimetablesDateRepository>();
        builder.Services.AddScoped<IDoctorTimetablesTimeRepository, DoctorTimetablesTimeRepository>();

        builder.Services.AddHostedService<Worker>();

        // Configura��o do DbContext
        builder.Services.AddDbContext<ApplicationDbContext>(
            options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"));
            }, ServiceLifetime.Scoped);

        // Adiciona health checks
        builder.Services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy());

        var host = builder.Build();

        /* INICIO DA CONFIGURA��O - PROMETHEUS */
        host.UseMetricServer();
        host.UseHttpMetrics(options =>
        {
            options.AddCustomLabel("host", context => context.Request.Host.Host);
        });
        /* FIM DA CONFIGURA��O - PROMETHEUS */

        // Configura os endpoints de health check
        host.MapHealthChecks("/health");
        host.MapHealthChecks("/readiness");

        host.Run();
    }
}