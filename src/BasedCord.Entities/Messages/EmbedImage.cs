﻿using System.Text.Json.Serialization;

namespace BasedCord.Entities.Messages
{
    public record EmbedImage
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("proxy_url")]
        public Optional<string> ProxyUrl { get; set; }

        [JsonPropertyName("height")]
        public Optional<int> Height { get; set; }

        [JsonPropertyName("width")]
        public Optional<int> Width { get; set; }
    }
}