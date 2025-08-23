using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirdAndBrew.Models;

public class Reservation
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [Range(1,100)]
    public int NumberOfGuests { get; set; }
    
    [Required]
    public DateTime ReservationDateTime { get; set; }
    
    //Can be used by Admin to see when a Reservation was made
    public DateTime CreatedAt { get; set; }
    
    //FK Customer
    [ForeignKey("Customer")]
    public int FK_CustomerId { get; set; }
    public Customer Customer { get; set; }
    
    //FK Table
    [ForeignKey("Table")]
    public int Fk_TableId { get; set; }
    public Table Table { get; set; }
    
}