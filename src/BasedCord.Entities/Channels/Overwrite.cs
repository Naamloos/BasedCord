using System.Text.Json.Serialization;

namespace BasedCord.Entities.Channels
{
    public record Overwrite
    {
        [JsonPropertyName("id")]
        public Snowflake Id { get; set; }

        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("allow")]
        public string AllowedPermissions { get; set; }

        [JsonPropertyName("deny")]
        public string DeniedPermissions { get; set; }
    }
}