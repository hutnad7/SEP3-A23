using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Cafe.dto;

public class EventDto{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("entertainerId")]
    public Guid EntertainerId { get; set; }
    [JsonPropertyName("cafeOwnerId")]
    public Guid CafeOwnerId { get; set; }
    [JsonPropertyName("entertainerName")]
    public string EntertainerName { get; set; }
    [JsonPropertyName("cafeOwnerName")]
    public string CafeOwnerName { get; set; }
 /*   [JsonPropertyName("startDate")]
    public DateTime Start { get; set; }
    [JsonPropertyName("endDate")]
    public DateTime End { get; set; }
    [JsonPropertyName("availablePlaces")]*/
    
    public int AvailablePlaces { get; set; }
    [JsonPropertyName("status")]
    public string Status { get; set; }

}
