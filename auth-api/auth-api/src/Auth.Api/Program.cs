using Auth.Api.Helpers.Middlewares;
using AuthControllers;
using AuthInterface;
using DataBase;
using DataBase.SqlServer.Configurations;
using DBGateways;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Prometheus;
using System.Reflection;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configuração: Carregar appsettings e arquivos específicos para o ambiente
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .Build();
        // Configuração do DbContext
        builder.Services.AddDbContext<ApplicationDbContext>(
            options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"));
            }, ServiceLifetime.Scoped);
        
        InstallServices(builder, configuration);

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth", Version = "v1" });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });

        builder.Services.UseHttpClientMetrics();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        /* INICIO DA CONFIGURAÇÃO - PROMETHEUS */
        app.UseMetricServer();
        app.UseHttpMetrics(options =>
        {
            options.AddCustomLabel("host", context => context.Request.Host.Host);
        });
        /* FIM DA CONFIGURAÇÃO - PROMETHEUS */

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseLoggingApi();
        app.MapControllers();

        // Configurar endpoints de sa�de
        app.MapHealthChecks("/health");
        app.MapHealthChecks("/readiness");

        app.Run();
    }

    private static void InstallServices(WebApplicationBuilder builder, IConfigurationRoot configuration)
    {
        builder.Services.AddLogging(builder => builder.AddConsole());
        builder.Services.AddHealthChecks();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddScoped<IController, AuthController>();
        builder.Services.AddScoped<IAuthDBGateway, AuthDbGateway>();
        builder.Services.AddScoped<IAuthRepository, AuthRepository>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IUserDBGateway, UserDbGateway>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
    }
}