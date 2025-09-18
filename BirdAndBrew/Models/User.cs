using System.ComponentModel.DataAnnotations;

namespace BirdAndBrew.Models;

public class User
{
    
    [Key] 
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }


    [Required] 
    public string Email { get; set; }
    
    [MaxLength(15)]
    public string Role { get; set; }

    [Required]
    public string PasswordHash { get; set; }
}