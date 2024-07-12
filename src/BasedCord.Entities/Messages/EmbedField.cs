using System.Text.Json.Serialization;

namespace BasedCord.Entities.Messages
{
    public record EmbedField
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("inline")]
        public Optional<bool> Inline { get; set; }
    }
}