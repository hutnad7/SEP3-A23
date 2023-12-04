using System.Text.Json.Serialization;

namespace Cafe.Models;
﻿namespace Cafe.Models;

public class Event
{
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("description")]
        public string Description { get; set; }
        
        public Guid EntertainerId { get; set; }
        
        [JsonPropertyName("cafeOwnerId")]
        public Guid CafeOwnerId { get; set; }
        
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        
        [JsonPropertyName("availablePlaces")]
        public int AvailablePlaces { get; set; }
}
        public int AvailablePlaces { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
}
