using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Data.Models;

public class Post : BaseEntity
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Content { get; set; }
    [Required]
    public User Author { get; set; }
    [Required]
    public Guid AuthorId { get; set; }
    public Event Event { get; set; }
    public Guid EventId { get; set; }

    [Required]
    public string CreationDate { get; set; }
    
}