using BasedCord.Gateway;
using BasedCord.Gateway.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasedCord.Interactions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInteractions(this IServiceCollection services, Action<InteractionConfiguration> configure)
        {
            services.AddSingleton<IExtension, InteractionExtension>(serviceProvider => new InteractionExtension(configure, serviceProvider));
            return services;
        }
    }
}
