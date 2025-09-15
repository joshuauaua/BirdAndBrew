using BirdAndBrew.DTOs.ReservationDTOs;
using BirdAndBrew.Models;

namespace BirdAndBrew.Services.ReservationServices;

public interface IReservationService
{
    //Get All Reservations
    Task<List<ReadReservationDTO>> GetAllReservationsAsync();
    
    //Get Reservation By ID
    Task<ReadReservationDTO> GetReservationByIdAsync(int reservationId);
    
    //Create New Reservation
    Task<bool> CreateReservationAsync(CreateReservationDTO createReservationDTO);

    //Update Reservation
    Task<bool> UpdateReservationAsync(int id, CreateReservationDTO reservationDTO);

    
    //Delete Reservation
    Task<bool> DeleteReservationAsync(int reservationId);

}