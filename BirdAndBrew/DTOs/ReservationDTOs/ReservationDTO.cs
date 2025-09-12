namespace BirdAndBrew.DTOs.ReservationDTOs;

public class ReservationDTO
{
    public int Id { get; set; }
    public int NumberOfGuests { get; set; }
    
    public DateOnly ReservationDate { get; set; }

    public TimeOnly ReservationStartTime { get; set; }
    public TimeOnly ReservationEndTime { get; set; }
    public int FK_CustomerId { get; set; }
    
    public int Fk_TableId { get; set; }
}