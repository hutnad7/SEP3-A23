using System.ComponentModel.DataAnnotations;

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
    [Required]
    public DateTime CreationDate { get; set; }
    
}