using System.ComponentModel.DataAnnotations;

namespace BirdAndBrew.Models;

public class Customer
{
    
    [Key]
    public int Id { get; set; } 
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    public string PhoneNumber { get; set; }
    
    //Can be used to see when a new customer was created, only visible to Admin
    public DateTime CreatedAt { get; set; }
    
    //List of Reservations to connect 
    public List<Reservation> Reservations { get; set; }
    
}