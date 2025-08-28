using BirdAndBrew.DTOs.ReservationDTOs;
using BirdAndBrew.Models;

namespace BirdAndBrew.Services.ReservationServices;

public interface IReservationService
{
    //Get All Reservations
    Task<List<ReservationDTO>> GetAllReservationsAsync();
    
    //Get Reservation By ID
    Task<ReservationDTO> GetReservationByIdAsync(int reservationId);

    //Create New Reservation
    Task<int> CreateNewReservationAsync(ReservationDTO reservationDTO);

    //Update Reservation
    Task<bool> UpdateReservationAsync(ReservationDTO reservationDTO);

    Task<bool> UpdateReservationFieldAsync(ReservationDTO reservationDTO);
    
    //Delete Reservation
    Task<bool> DeleteReservationAsync(int reservationId);

}