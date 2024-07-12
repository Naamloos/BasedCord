using System.Text.Json.Serialization;

namespace BasedCord.Entities.Messages
{
    public record EmbedProvider
    {
        [JsonPropertyName("name")]
        public Optional<string> Name { get; set; }

        [JsonPropertyName("url")]
        public Optional<string> Url { get; set; }
    }
}