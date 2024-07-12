using BasedCord.Entities.Enums;
using System.Text.Json.Serialization;

namespace BasedCord.Entities.Messages
{
    public record MessageActivity
    {
        [JsonPropertyName("type")]
        public MessageActivityType Type { get; set; }

        [JsonPropertyName("party_id")]
        public Optional<string> PartyId { get; set; }
    }
}