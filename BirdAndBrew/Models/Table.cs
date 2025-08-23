using System.ComponentModel.DataAnnotations;

namespace BirdAndBrew.Models;

public class Table
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [Range(1,20)]
    public int TableNumber { get; set; }
    
    [Required]
    [Range(1,20)]
    public int Capacity { get; set; }
    
    //List of reservations 
    public List<Reservation> Reservations { get; set; }
}