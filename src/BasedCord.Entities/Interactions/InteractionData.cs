﻿using BasedCord.Entities.Enums;
using System.Text.Json.Serialization;

namespace BasedCord.Entities.Interactions
{
    public record InteractionData
    {
        [JsonPropertyName("id")]
        public Snowflake CommandId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public ApplicationCommandType Type { get; set; }

        [JsonPropertyName("resolved")]
        public Optional<ResolvedDataStructure> Resolved { get; set; }

        [JsonPropertyName("options")]
        public Optional<List<ApplicationCommandInteractionDataOption>> Options { get; set; }

        [JsonPropertyName("guild_id")]
        public Optional<Snowflake> GuildId { get; set; }

        [JsonPropertyName("target_id")]
        public Optional<Snowflake> TargetId { get; set; }
    }
}