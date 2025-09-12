using BirdAndBrew.Data;
using BirdAndBrew.DTOs.ReservationDTOs;
using BirdAndBrew.DTOs.TableDTOs;
using BirdAndBrew.Models;
using BirdAndBrew.Repositories.ReservationRepositories;
using BirdAndBrew.Repositories.TableRepositories;
using BirdAndBrew.Services.BookingAvailabilityServices;

namespace BirdAndBrew.Services.ReservationServices;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _context;
    private readonly IBookingAvailabilityService _booker;

    public ReservationService(IReservationRepository context, IBookingAvailabilityService booker)
    {
        _context = context;
        _booker = booker;
    }

    
    
    //GET ALL RESERVATIONS
    public async Task<List<ReadReservationDTO>> GetAllReservationsAsync()
    {
        var reservations = await _context.GetAllReservationsAsync();

        var reservationsDTO = reservations.Select(r => new ReadReservationDTO
        {
            Id = r.Id,
            NumberOfGuests = r.NumberOfGuests,
            ReservationStartTime = r.ReservationStartTime,
            ReservationEndTime = r.ReservationStartTime.AddHours(2),
            ReservationDate = r.ReservationDate,
            FK_CustomerId = r.FK_CustomerId,
            Fk_TableId = r.Fk_TableId
        }).ToList();

        return reservationsDTO;
    }
    
    
    
    
    //GET BY ID
    public async Task<ReadReservationDTO> GetReservationByIdAsync(int reservationId)
    {
        var reservation = await _context.GetReservationByIdAsync(reservationId);

        if (reservation == null)
        {
            return null;
        }
        
        var reservationDTO = new ReadReservationDTO
        {
            Id = reservation.Id,
            NumberOfGuests = reservation.NumberOfGuests,
            ReservationStartTime = reservation.ReservationStartTime,
            ReservationEndTime = reservation.ReservationStartTime.AddHours(2),
            ReservationDate = reservation.ReservationDate,
            FK_CustomerId = reservation.FK_CustomerId,
            Fk_TableId = reservation.Fk_TableId
        };

        return reservationDTO;
        
    }
    
    
    
    
    
    
    //POST
    public async Task<bool> CreateReservationAsync(CreateReservationDTO createReservationDTO)
    {
        var reservation = new Reservation
        {
            NumberOfGuests = createReservationDTO.NumberOfGuests,
            ReservationStartTime = createReservationDTO.ReservationStartTime,
            ReservationEndTime = createReservationDTO.ReservationStartTime.AddHours(2),
            ReservationDate = createReservationDTO.ReservationDate,
            FK_CustomerId = createReservationDTO.FK_CustomerId,
            Fk_TableId = createReservationDTO.Fk_TableId
        };
        
            await _context.CreateNewReservationAsync(reservation);
            
            return true;
        
    }
    
    
    
    
    

    public async Task<bool> UpdateReservationAsync(ReadReservationDTO readReservationDTO)
    {
        var existing = await _context.GetReservationByIdAsync(readReservationDTO.Id);

        if (existing == null)
        {
            return false;
        }

        existing.NumberOfGuests = readReservationDTO.NumberOfGuests;
        existing.ReservationStartTime = readReservationDTO.ReservationStartTime;
        existing.ReservationEndTime = readReservationDTO.ReservationStartTime.AddHours(2);
        existing.ReservationDate = readReservationDTO.ReservationDate;
        existing.FK_CustomerId = readReservationDTO.FK_CustomerId;
        existing.Fk_TableId = readReservationDTO.Fk_TableId;

        await _context.UpdateReservationAsync(existing);
        
        return true;
    }

    public async Task<bool> UpdateReservationFieldAsync(ReadReservationDTO readReservationDTO)
    {
        var existing = await _context.GetReservationByIdAsync(readReservationDTO.Id);

        if (existing == null)
        {
            return false;
        }

        if (existing.NumberOfGuests != null)
            existing.NumberOfGuests = readReservationDTO.NumberOfGuests;
        
        if (existing.ReservationStartTime != null)
            existing.ReservationStartTime = readReservationDTO.ReservationStartTime;
        existing.ReservationEndTime = readReservationDTO.ReservationStartTime.AddHours(2);
        
        if (existing.ReservationDate != null)
            existing.ReservationDate = readReservationDTO.ReservationDate;
        
        if (existing.FK_CustomerId != null)
            existing.FK_CustomerId = readReservationDTO.FK_CustomerId;
        
        if (existing.Fk_TableId != null)
            existing.Fk_TableId = readReservationDTO.Fk_TableId;

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