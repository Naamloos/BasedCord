using BasedCord.Gateway.Events;
using System.Text.Json.Serialization;

namespace BasedCord.Gateway.EventData.Incoming
{
    public record Hello : IPublishable
    {
        [JsonPropertyName("heartbeat_interval")]
        public int HeartbeatInterval { get; set; }
    }
}
