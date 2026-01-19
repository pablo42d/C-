using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Lab06.zadanie2
{
    internal class PopulationRecord
    {
        [JsonPropertyName("country")]
        public Country Country { get; set; } = new();

        [JsonPropertyName("value")]
        public string? Value { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; } = "";
    }

    internal class Country
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = "";

        [JsonPropertyName("value")]
        public string Name { get; set; } = "";        
    }
}
