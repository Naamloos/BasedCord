﻿using BasedCord.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BasedCord.Entities.Interactions
{
    public record InteractionResponse
    {
        [JsonPropertyName("type")]
        public InteractionResponseType Type { get; set; }

        [JsonPropertyName("data")]
        public Optional<InteractionResponseData> Data { get; set; }
    }
}
