using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace External.Interfaces;

public static class RefitServiceExtension
{
    public static void AddRefitServiceExtension(this IServiceCollection services, IConfiguration configuration)
    {
        /*
        services.AddRefitClient<IDoctorTimetablesExternal>().ConfigureHttpClient(c =>
        {
            c.BaseAddress = new Uri(configuration["DoctorTimetablesConsulting:Uri"]);
            c.Timeout = TimeSpan.FromSeconds(1);
        }); 
        */
        services.AddRefitClient<INotificationExternal>().ConfigureHttpClient(c =>
        {
            c.BaseAddress = new Uri(configuration["DoctorTimetablesConsulting:Uri"]);
            c.Timeout = TimeSpan.FromSeconds(1);
        });

        
    }
    
}