using System.Runtime.InteropServices.JavaScript;

namespace Shared.Models;

public class Post
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string EventId { get; set; }
    public string Content { get; set; }
    public Guid AuthorId { get; set; }
    public string Date { get; set; }
}