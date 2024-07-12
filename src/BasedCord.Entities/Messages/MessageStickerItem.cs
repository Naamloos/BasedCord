using BasedCord.Entities.Enums;
using System.Text.Json.Serialization;

namespace BasedCord.Entities.Messages
{
    public record MessageStickerItem
    {
        [JsonPropertyName("id")]
        public Snowflake Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("format_type")]
        public StickerFormat FormatType { get; set; }
    }
}