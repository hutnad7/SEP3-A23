using System.Text.Json.Serialization;

namespace Shared.Dtos;

public class UserLoginDto
{
    [JsonPropertyName("email")]
    public string Email { get; init; }
    [JsonPropertyName("password")]
    public string Password { get; init; }
}