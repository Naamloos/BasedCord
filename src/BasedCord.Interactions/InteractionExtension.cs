using BasedCord.Gateway;
using BasedCord.Gateway.EventData.Incoming;
using BasedCord.Gateway.Extensions;
using BasedCord.Interactions.Subscribers;

namespace BasedCord.Interactions
{
    public class InteractionExtension : IExtension
    {
        private InteractionConfiguration _config;
        private IServiceProvider _services;

        internal InteractionExtension(Action<InteractionConfiguration> configure, IServiceProvider services)
        {
            _config = new InteractionConfiguration();
            configure(_config);
            _services = services;
        }

        public void Register(DiscordGateway gateway)
        {
            gateway.RegisterSubscriber<InteractionSubscriber>();
        }

        internal void registerInteractions()
        {
            // TODO register all interactions here
        }

        internal async ValueTask handleInteractionAsync(InteractionCreate data)
        {
            // TODO handle interactions here
        }
    }
}
