﻿using BasedCord.Entities.Enums;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace BasedCord.Entities.Interactions
{
    public record ApplicationCommandInteractionDataOption
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public ApplicationCommandOptionType Type { get; set; }

        [JsonPropertyName("value")]
        public Optional<JsonNode> Value { get; set; }

        [JsonPropertyName("options")]
        public Optional<List<ApplicationCommandInteractionDataOption>> Options { get; set; }

        [JsonPropertyName("focused")]
        public Optional<bool> Focused { get; set; }
    }
}