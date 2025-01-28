﻿using CreateController;
using CreateInterface;
using ExternalInterfaceGateway;
using Microsoft.OpenApi.Models;
using Rabbit.Producer.Create;
using External.Interfaces;
using Prometheus;
using Create.Api.Helpers.Middlewares;
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

        InstallServices(builder, configuration);

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Usuário", Version = "v1" });
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

        builder.Services.AddRabbitMq(configuration);
        builder.Services.AddRefitServiceExtension(configuration);

        builder.Services.AddScoped<IController, CreateUserController>();
        builder.Services.AddScoped<IUserProducer, UserProducer>();
        builder.Services.AddScoped<IUserConsultingGateway, UserConsultingGateway>();
    }
}