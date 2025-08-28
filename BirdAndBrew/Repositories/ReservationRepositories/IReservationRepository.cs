using BirdAndBrew.Models;

namespace BirdAndBrew.Repositories.ReservationRepositories;

public interface IReservationRepository
{
    //Get All Reservations
    Task<List<Reservation>> GetAllReservationsAsync();
    
    
    //Get Reservation By ID
    Task<Reservation> GetReservationByIdAsync(int reservationId);

   //Get Available Tables
   Task<List<Reservation>> GetOverlappingReservationsAsync(DateTime startTime, DateTime endTime);
    
    //Create New Reservation
    Task<int> CreateNewReservationAsync(Reservation reservation);

    //Update Reservation
    Task<bool> UpdateReservationAsync(Reservation reservation);
    
    //Delete Reservation
    Task<bool> DeleteReservationAsync(int reservationId);
    
}