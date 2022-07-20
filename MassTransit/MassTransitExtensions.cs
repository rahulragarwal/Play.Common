using MassTransit;
using MassTransit.Definition;
using Microsoft.Extensions.DependencyInjection;
using Play.Catalog.Service.Settings;
using Play.Common.Settings;
using System.Reflection;

namespace Play.Common.MassTransit
{
    public static class MassTransitExtensions
    {
        public static IServiceCollection AddMassTransitWithRabbitMQ(this IServiceCollection services, RabbitMQSettings rabbitMQSettings, ServiceSettings serviceSettings)
        {
            
            services.AddMassTransit(ServiceProvider =>
            {
                ServiceProvider.AddConsumers(Assembly.GetEntryAssembly());
                ServiceProvider.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(rabbitMQSettings.Host);
                    configurator.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(serviceSettings.ServiceName, false));
                });
            });

            services.AddMassTransitHostedService();
            return services;
        }
    }
}
