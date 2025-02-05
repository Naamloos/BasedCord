﻿using BasedCord.Entities.Enums;
using System.Text.Json.Serialization;

namespace BasedCord.Entities.Messages
{
    public record Attachment
    {
        [JsonPropertyName("id")]
        public Snowflake Id { get; set; }

        [JsonPropertyName("filename")]
        public string Filename { get; set; }

        [JsonPropertyName("description")]
        public Optional<string> Description { get; set; }

        [JsonPropertyName("content_type")]
        public Optional<string> ContentType { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("proxy_url")]
        public string ProxyUrl { get; set; }

        [JsonPropertyName("height")]
        public Optional<int?> Height { get; set; }

        [JsonPropertyName("width")]
        public Optional<int?> Width { get; set; }

        [JsonPropertyName("ephemeral")]
        public Optional<bool> Ephemeral { get; set; }

        [JsonPropertyName("duration_seconds")]
        public Optional<float> DurationSeconds { get; set; }

        [JsonPropertyName("waveform")]
        public Optional<string> WaveForm { get; set; }

        [JsonPropertyName("flags")]
        public Optional<AttachmentFlags> Flags { get; set; }
    }
}