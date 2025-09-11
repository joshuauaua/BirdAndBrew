using System.ComponentModel.DataAnnotations;

namespace BirdAndBrew.Models;

public class Customer
{
    
    [Key]
    public int Id { get; set; } 
    
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
     
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    
    [Required]
    [Phone]
    public string PhoneNumber { get; set; }
    
    [Required]
    [EmailAddress]
    public string EmailAddress { get; set; }
    
    //List of Reservations to connect 
    public List<Reservation> Reservations { get; set; }
    
}