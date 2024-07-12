using BasedCord.Entities.Enums;
using BasedCord.Entities.Guilds;
using System.Text.Json.Serialization;

namespace BasedCord.Entities.Messages
{
    public record MessageInteraction
    {
        [JsonPropertyName("id")]
        public Snowflake Id { get; set; }

        [JsonPropertyName("type")]
        public InteractionType Type { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("user")]
        public User User { get; set; }

        [JsonPropertyName("member")]
        public Member Member { get; set; }
    }
}