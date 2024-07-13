using BasedCord.Entities.Interactions;
using BasedCord.Gateway;
using BasedCord.Gateway.EventData.Incoming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasedCord.Interactions.Contexts
{
    public class CommandContext
    {
        public InteractionCreate EventData { get; }
        public DiscordGateway Gateway { get; }
        public List<ApplicationCommandInteractionDataOption> Options => EventData.Data.Value.Options;

        public CommandContext(InteractionCreate eventData, DiscordGateway gateway)
        {
            EventData = eventData;
            Gateway = gateway;
        }
    }
}
