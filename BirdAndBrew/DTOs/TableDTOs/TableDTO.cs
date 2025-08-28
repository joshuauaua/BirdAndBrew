using BirdAndBrew.DTOs.ReservationDTOs;
using BirdAndBrew.Models;

namespace BirdAndBrew.DTOs.TableDTOs;

public class TableDTO
{
    public int Id { get; set; }
    
    public int TableNumber { get; set; }
    
    public int Capacity { get; set; }

    public List<ReservationDTO> Reservations { get; set; } 

}