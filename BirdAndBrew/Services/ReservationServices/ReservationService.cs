using BirdAndBrew.Data;
using BirdAndBrew.DTOs.ReservationDTOs;
using BirdAndBrew.DTOs.TableDTOs;
using BirdAndBrew.Models;
using BirdAndBrew.Repositories.ReservationRepositories;
using BirdAndBrew.Repositories.TableRepositories;

namespace BirdAndBrew.Services.ReservationServices;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _context;

    public ReservationService(IReservationRepository context)
    {
        _context = context;
    }

    
    public async Task<List<ReservationDTO>> GetAllReservationsAsync()
    {
        var reservations = await _context.GetAllReservationsAsync();

        var reservationsDTO = reservations.Select(r => new ReservationDTO
        {
            Id = r.Id,
            NumberOfGuests = r.NumberOfGuests,
            ReservationStartTime = r.ReservationStartTime,
            ReservationEndTime = r.ReservationStartTime.AddHours(2),
            FK_CustomerId = r.FK_CustomerId,
            Fk_TableId = r.Fk_TableId
        }).ToList();

        return reservationsDTO;
    }

    
    
    
    
    
    public async Task<ReservationDTO> GetReservationByIdAsync(int reservationId)
    {
        var reservation = await _context.GetReservationByIdAsync(reservationId);

        if (reservation == null)
        {
            return null;
        }
        
        var reservationDTO = new ReservationDTO
        {
            Id = reservation.Id,
            NumberOfGuests = reservation.NumberOfGuests,
            ReservationStartTime = reservation.ReservationStartTime,
            ReservationEndTime = reservation.ReservationStartTime.AddHours(2),
            FK_CustomerId = reservation.FK_CustomerId,
            Fk_TableId = reservation.Fk_TableId
        };

        return reservationDTO;
        
    }
    
    
    
    
    
    

    public async Task<int> CreateNewReservationAsync(ReservationDTO reservationDTO)
    {
        var reservation = new Reservation
        {
            NumberOfGuests = reservationDTO.NumberOfGuests,
            ReservationStartTime = reservationDTO.ReservationStartTime,
            ReservationEndTime = reservationDTO.ReservationStartTime.AddHours(2),
            FK_CustomerId = reservationDTO.FK_CustomerId,
            Fk_TableId = reservationDTO.Fk_TableId
        };
        
        
        var newReservationId = await _context.CreateNewReservationAsync(reservation);

        return newReservationId;
    }

    public async Task<bool> UpdateReservationAsync(ReservationDTO reservationDTO)
    {
        var existing = await _context.GetReservationByIdAsync(reservationDTO.Id);

        if (existing == null)
        {
            return false;
        }

        existing.NumberOfGuests = reservationDTO.NumberOfGuests;
        existing.ReservationStartTime = reservationDTO.ReservationStartTime;
        existing.ReservationEndTime = reservationDTO.ReservationStartTime.AddHours(2);
        existing.FK_CustomerId = reservationDTO.FK_CustomerId;
        existing.Fk_TableId = reservationDTO.Fk_TableId;

        await _context.UpdateReservationAsync(existing);
        
        return true;
    }

    public async Task<bool> UpdateReservationFieldAsync(ReservationDTO reservationDTO)
    {
        var existing = await _context.GetReservationByIdAsync(reservationDTO.Id);

        if (existing == null)
        {
            return false;
        }

        if (existing.NumberOfGuests != null)
            existing.NumberOfGuests = reservationDTO.NumberOfGuests;
        
        if (existing.ReservationStartTime != null)
            existing.ReservationStartTime = reservationDTO.ReservationStartTime;
        existing.ReservationEndTime = reservationDTO.ReservationStartTime.AddHours(2);
        
        if (existing.FK_CustomerId != null)
            existing.FK_CustomerId = reservationDTO.FK_CustomerId;
        
        if (existing.Fk_TableId != null)
            existing.Fk_TableId = reservationDTO.Fk_TableId;

        await _context.UpdateReservationAsync(existing);
        
        return true;
    }

    
    public async Task<bool> DeleteReservationAsync(int reservationId)
    {
        if (reservationId == null)
        {
            return false;
        }
        await _context.DeleteReservationAsync(reservationId);
        return true;
    }
}