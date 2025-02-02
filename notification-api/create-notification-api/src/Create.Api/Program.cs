﻿using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using Prometheus;
using Create.Api.Helpers.Middlewares;
using Controllers.Create;
using System.Text;
using External.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Gateways.External;
using Rabbit.Producer.Create;
using Gateways.Queue;

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
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cadastros de Horários", Version = "v1" });

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

        builder.Services.AddRefitServiceExtension(configuration);
        
        builder.Services.AddScoped<IController, CreateNotificationController>();
        builder.Services.AddScoped<INotificationGateway, NotificationGateway>();
        builder.Services.AddScoped<INotificationProducer, NotificationProducer>();
        builder.Services.AddScoped<INotificationQueueGateway, NotificationQueueGateway>();
    }
}