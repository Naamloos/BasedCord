using BasedCord.Entities.Guilds;
using BasedCord.Entities.Messages;
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
    public record MessageUpdate : Message, IPublishable
    {
        [JsonPropertyName("guild_id")]
        public Snowflake? GuildId { get; set; }

        [JsonPropertyName("member")]
        public Member Member { get; set; }
    }
}
