namespace BirdAndBrew.DTOs.ReservationDTOs;

public class ReservationDTO
{
    public int Id { get; set; }
    public int NumberOfGuests { get; set; }
    public DateTime ReservationDateTime { get; set; }
    
    public int FK_CustomerId { get; set; }
    
    public int Fk_TableId { get; set; }
}