using System.ComponentModel.DataAnnotations;

namespace BirdAndBrew.Models;

public class MenuItem
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Description { get; set; }
    
    [Required] 
    public int Price { get; set; }
    
    public string? Image { get; set; }
    public bool IsPopular { get; set; }
    
}