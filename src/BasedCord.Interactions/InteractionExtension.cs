using BasedCord.Gateway;

namespace BasedCord.Interactions
{
    public class InteractionExtension : BaseExtension
    {
        private InteractionConfiguration _config;
        private IServiceProvider _services;

        internal InteractionExtension(Action<InteractionConfiguration> configure, IServiceProvider services)
        {
            _config = new InteractionConfiguration();
            configure(_config);
            _services = services;
        }

        public override void Register(DiscordGateway gateway)
        {
            throw new NotImplementedException();
        }
    }
}
