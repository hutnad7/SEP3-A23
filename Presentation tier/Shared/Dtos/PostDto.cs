using System.Text.Json.Serialization;

namespace Shared.Dtos;

public class PostDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("content")]
    public string Content { get; set; }
    [JsonPropertyName("author")]
    public Guid AuthorId { get; set; }
    [JsonPropertyName("authorName")]
    public string AuthorName { get; set; }

}