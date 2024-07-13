using BasedCord.Gateway.EventData.Incoming;
using BasedCord.Gateway.Events;
using BasedCord.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BasedCord.ExampleBot.Events
{
    // A subscriber class can implement multiple ISubscriber interfaces for available events
    public class ExampleSubscriber : ISubscriber<Ready>, ISubscriber<Hello>, ISubscriber<GuildCreate>
    {
        // The DiscordGateway instance is always injected by the gateway, because hosted services can't be injected into subscribers
        public DiscordGateway Gateway { get; set; }
        private readonly ILogger<ExampleSubscriber> _logger;

        // Subscribers support dependency injection, so we can just inject the logger.
        // Subscribers are always singletons, so these are only created once.
        public ExampleSubscriber(ILogger<ExampleSubscriber> logger)
        {
            _logger = logger;
        }

        // All of the following methods are the handlers for the events defined by the ISubscriber interfaces
        public async ValueTask HandleEvent(Ready data)
        {
            _logger.LogInformation("Ready event! from ExampleSubscriber");
        }

        public async ValueTask HandleEvent(Hello data)
        {
            _logger.LogInformation("Hello event! from ExampleSubscriber");
        }

        public async ValueTask HandleEvent(GuildCreate data)
        {
            _logger.LogInformation("Received GuildCreate in ExampleSubscriber for guild: {0}", data.Name);
        }
    }
}
