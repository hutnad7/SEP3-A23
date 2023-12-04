using System.Text.Json.Serialization;

namespace Cafe.Models;

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
        [JsonPropertyName("startDate")]

        public DateTime Start { get; set; }
        [JsonPropertyName("endDate")]
        public DateTime End { get; set; }
}
