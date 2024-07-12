using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BasedCord.ExampleBot
{
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
