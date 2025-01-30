using System.Text.Json.Serialization;
using CacheGateway;
using ConsultingInterface;
using Microsoft.OpenApi.Models;
using Prometheus;
using Create.Api.Helpers.Middlewares;
using DataBase;
using DataBase.SqlServer.Configurations;
using DBGateways;
using Microsoft.EntityFrameworkCore;
using ConsultingController;
using Redis;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .Build();
        
        InstallServices(builder, configuration);
        
        builder.Services.UseHttpClientMetrics();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseMetricServer();
        app.UseHttpMetrics(options =>
        {
            options.AddCustomLabel("host", context => context.Request.Host.Host);
        });

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseLoggingApi();
        app.MapControllers();

        app.MapHealthChecks("/health");
        app.MapHealthChecks("/readiness");

        app.Run();
    }

    private static void InstallServices(WebApplicationBuilder builder, IConfigurationRoot configuration)
    {
        builder.Services.AddLogging(builder => builder.AddConsole());
        builder.Services.AddHealthChecks();
        builder
            .Services
            .AddDbContext<ApplicationDbContext>(
                options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("ConnectionString"));
                }, ServiceLifetime.Scoped);
        
        builder
            .Services
            .AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Usuários", Version = "v1" });
            });

        builder
            .Services
            .AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddRedis(configuration);

        builder.Services.AddScoped<IController, ConsultingDoctorController>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IUserDBGateway, UserDbGateway>();
        builder.Services.AddScoped<ICache, Cache>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
    }
}