using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Cafe.Models;

public class Event{
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
    [JsonPropertyName("startDate")]
    public string Start { get; set; }
    [JsonPropertyName("endDate")]
    public string End { get; set; }
    [JsonPropertyName("availablePlaces")]
    
    public int AvailablePlaces { get; set; }
    [JsonPropertyName("status")]
    public string Status { get; set; }

}