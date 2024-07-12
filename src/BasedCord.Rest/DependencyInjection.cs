using Microsoft.Extensions.DependencyInjection;

namespace BasedCord.Rest
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDiscordRest(this IServiceCollection services, Action<DiscordRestConfiguration> configure)
        {
            services.AddSingleton(serviceProvider => new DiscordRest(configure, serviceProvider));
            return services;
        }
    }
}
