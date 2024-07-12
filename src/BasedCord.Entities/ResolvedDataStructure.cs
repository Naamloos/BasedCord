using System.Text.Json.Serialization;
using BasedCord.Entities.Channels;
using BasedCord.Entities.Guilds;
using BasedCord.Entities.Messages;

namespace BasedCord.Entities
{
    public record ResolvedDataStructure
    {
        [JsonPropertyName("users")]
        public Optional<Dictionary<string, User>> Users { get; set; }

        [JsonPropertyName("members")]
        public Optional<Dictionary<string, Member>> Members { get; set; }

        [JsonPropertyName("channels")]
        public Optional<Dictionary<string, Channel>> Channel { get; set; }

        [JsonPropertyName("messages")]
        public Optional<Dictionary<string, Message>> Messages { get; set; }

        [JsonPropertyName("attachments")]
        public Optional<Dictionary<string, Attachment>> Attachments { get; set; }
    }
}