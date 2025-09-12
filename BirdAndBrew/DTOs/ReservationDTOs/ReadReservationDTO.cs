namespace BirdAndBrew.DTOs.ReservationDTOs;

public class ReadReservationDTO
{
    public int Id { get; set; }
    public int NumberOfGuests { get; set; }
    public DateTime ReservationDate { get; set; }

    public DateTime ReservationStartTime { get; set; }
    public DateTime ReservationEndTime { get; set; }
    public int FK_CustomerId { get; set; }
    public int Fk_TableId { get; set; }
}