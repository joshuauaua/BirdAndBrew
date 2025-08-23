using System.ComponentModel.DataAnnotations;

namespace BirdAndBrew.Models;

public class Admin
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string UserName { get; set; }
    
    [Required]
    [MinLength(8)]
    public string Password { get; set; }
    
}