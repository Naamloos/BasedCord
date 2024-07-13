using BasedCord.Gateway;
using BasedCord.Gateway.EventData.Incoming;
using BasedCord.Gateway.Events;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("BasedCord.Gateway")]
namespace BasedCord.Interactions.Subscribers
{
    public class InteractionSubscriber : ISubscriber<InteractionCreate>, ISubscriber<Ready>
    {
        public DiscordGateway Gateway { get; set; }
        private ILogger<InteractionSubscriber> _logger;
        private InteractionExtension _interactionExtension;

        public InteractionSubscriber(DiscordGateway gateway, IServiceProvider services, InteractionExtension interactionExtension)
        {
            Gateway = gateway;

            _logger = (ILogger<InteractionSubscriber>?)services.GetService(typeof(ILogger<InteractionSubscriber>)) 
                ?? new Logger<InteractionSubscriber>(NullLoggerFactory.Instance);
        }

        public ValueTask HandleEvent(InteractionCreate data)
            => _interactionExtension.handleInteractionAsync(data);

        public ValueTask HandleEvent(Ready data)
        {
            // register interactions!
            _logger.LogInformation("Discord event READY received! Registering interactions...");
            _interactionExtension.registerInteractions();
            return ValueTask.CompletedTask;
        }
    }
}
