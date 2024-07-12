using System.Text.Json.Serialization;

namespace BasedCord.Entities.Guilds
{
    public record WelcomeScreen
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("welcome_channels")]
        public WelcomeScreenChannel[] WelcomeChannels { get; set; }
    }
}