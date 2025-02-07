using System.Text.Json.Serialization;
using DeleteInterface;
using Microsoft.OpenApi.Models;
using Prometheus;
using Delete.Api.Helpers.Middlewares;
using DeleteController;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using QueueGateway;
using Rabbit.Producer.Delete;
using System.Reflection;

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
        builder.Services.AddRabbitMq(configuration);

        builder.Services.AddLogging(builder => builder.AddConsole());
        builder.Services.AddHealthChecks();
   
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "API para Deletar Horários", Version = "v1" });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);

            // Adiciona suporte para passar o token JWT no Swagger
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        });
        });

        builder
            .Services
            .AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

        var key = Encoding.ASCII.GetBytes(configuration["SecretJWT"]);
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false; // Somente para desenvolvimento, mude para true em produção
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false, // Você pode configurar isso dependendo das suas necessidades
                    ValidateAudience = false // Você pode configurar isso dependendo das suas necessidades
                };
            });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddScoped<IController, DeleteDoctorController>();
        builder.Services.AddScoped<IDoctorTimetablesProducer, DoctorTimetablesProducer>();
        builder.Services.AddScoped<IDoctorTimetablesQueueGateway, DoctorTimetablesQueueGateway>();
    }
}