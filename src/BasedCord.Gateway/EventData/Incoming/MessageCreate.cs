using BasedCord.Entities;
using BasedCord.Entities.Guilds;
using BasedCord.Entities.Messages;
using BasedCord.Gateway.Events;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace BasedCord.Gateway.EventData.Incoming
{
    public record MessageCreate : Message, IPublishable
    {
        [JsonPropertyName("guild_id")]
        public Snowflake? GuildId { get; set; }

        [JsonPropertyName("member")]
        public Member Member { get; set; }
    }
}
