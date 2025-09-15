using System.ComponentModel.DataAnnotations;

namespace BirdAndBrew.Models;

public class Admin
{
    [Key]
    public int Id { get; set; }

    [Required] 
    [EmailAddress]
    [MaxLength(50)] public string Username { get; set; } = string.Empty;

    [Required] [MinLength(8)] public string Password { get; set; } = string.Empty;
    
    [Required]
    public string Role { get; set; }
    
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
     
}