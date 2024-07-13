using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BasedCord.ExampleBot
{
    /// <summary>
    /// This Settings class is used to load data about the current Shard.
    /// </summary>
    public record Settings
    {
        [JsonPropertyName("discord_token")]
        public string Token { get; set; } = "";

        [JsonPropertyName("shard_count")]
        public int ShardCount { get; set; } = 1;

        [JsonPropertyName("shard_id")]
        public int CurrentShard { get; set; } = 0;
    }
}
