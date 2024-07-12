using BasedCord.Entities;
using BasedCord.Gateway.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BasedCord.Gateway.EventData.Incoming
{
    public record MessageBulkDelete : IPublishable
    {
        [JsonPropertyName("ids")]
        public Snowflake[] Ids { get; set; }

        [JsonPropertyName("channel_id")]
        public Snowflake ChannelId { get; set; }

        [JsonPropertyName("guild_id")]
        public Optional<Snowflake> GuildId { get; set; }
    }
}
