using BasedCord.Entities.Channels;
using BasedCord.Gateway.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasedCord.Gateway.EventData.Incoming
{
    public record ChannelCreate : Channel, IPublishable
    {
    }
}
