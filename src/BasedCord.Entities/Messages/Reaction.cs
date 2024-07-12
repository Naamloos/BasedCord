using System.Text.Json.Serialization;

namespace BasedCord.Entities.Messages
{
    public record Reaction
    {
        [JsonPropertyName("emoji_id")]
        public Snowflake? EmojiId { get; set; }

        [JsonPropertyName("emoji_name")]
        public string? EmojiName { get; set; }
    }
}