using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace External.Interfaces;

public static class RefitServiceExtension
{
    public static void AddRefitServiceExtension(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRefitClient<IDoctorTimetablesExternal>(new RefitSettings
        {
            ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true 
            })
        })
        .ConfigureHttpClient(c =>
        {
            c.BaseAddress = new Uri(configuration["DoctorTimetablesConsulting:Uri"]);
            c.Timeout = TimeSpan.FromSeconds(1);
        });    
    }
    
}