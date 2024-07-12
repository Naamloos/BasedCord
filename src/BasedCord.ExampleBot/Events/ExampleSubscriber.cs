using BasedCord.Gateway.EventData.Incoming;
using BasedCord.Gateway.Events;
using BasedCord.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasedCord.ExampleBot.Events
{
    public class ExampleSubscriber : ISubscriber<Ready>, ISubscriber<Hello>, ISubscriber<GuildCreate>
    {
        public DiscordGateway Gateway { get; set; }

        public async ValueTask HandleEvent(Ready data)
        {
            
        }

        public async ValueTask HandleEvent(Hello data)
        {

        }

        public async ValueTask HandleEvent(GuildCreate data)
        {

        }
    }
}
