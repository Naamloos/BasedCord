using BasedCord.Gateway;
using BasedCord.Gateway.EventData.Incoming;
using BasedCord.Gateway.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("BasedCord.Gateway")]
namespace BasedCord.Interactions.Subscribers
{
    internal class InteractionSubscriber : ISubscriber<InteractionCreate>, ISubscriber<Ready>
    {
        public DiscordGateway Gateway { get; set; }

        public async ValueTask HandleEvent(InteractionCreate data)
        {
            
        }

        public async ValueTask HandleEvent(Ready data)
        {
            
        }
    }
}
