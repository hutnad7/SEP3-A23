using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public class Auth
{
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
}