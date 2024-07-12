using Microsoft.Extensions.DependencyInjection;

namespace BasedCord.Gateway
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDiscordGateway(this IServiceCollection services, Action<GatewayConfiguration> configure)
        {
            services.AddHostedService(serviceProvider => new DiscordGateway(configure, serviceProvider));
            return services;
        }
    }
}
