using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Rabbit.Consumer;

public static class RabbitServiceExtension
{
    public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
    {
        var host = configuration["Rabbit:Host"];
        ushort port = Convert.ToUInt16(configuration["Rabbit:Port"]);
        var user = configuration["Rabbit:User"];
        var password = configuration["Rabbit:Password"];

        services.AddMassTransit(register =>
        {
            //register.AddConsumer<UpdateContactConsumer>();
            register.AddConsumer<NotificationConsumer>();

            register.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(host, port, "/", h =>
                {
                    
                    h.Username(user);
                    h.Password(password);
                });
              
                cfg.ReceiveEndpoint("appointment-create", receiver =>
                {
                    receiver.ConfigureConsumer<NotificationConsumer>(context);
                    receiver.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));
                });
            });          
        });
    }
}
