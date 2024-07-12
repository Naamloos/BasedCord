using BasedCord.Entities.Interactions;
using BasedCord.Gateway.Events;

namespace BasedCord.Gateway.EventData.Incoming
{
    public record InteractionCreate : Interaction, IPublishable
    {

    }
}
