using BirdAndBrew.Data;
using BirdAndBrew.Models;
using BirdAndBrew.Repositories.ReservationRepositories;
using Microsoft.EntityFrameworkCore;

namespace BirdAndBrew.Repositories.ReservationRepositories;

public class ReservationRepository : IReservationRepository
{

    private readonly AppDBContext _context;

    public ReservationRepository(AppDBContext context)
    {
        _context = context;
    }
    
    public async Task<List<Reservation>> GetAllReservationsAsync()
    {
        var reservations = await _context.Reservations.ToListAsync();

        return reservations;
    }
    

    public async Task<Reservation> GetReservationByIdAsync(int reservationId)
    {

        var reservation = await _context.Reservations.FirstOrDefaultAsync(r => r.Id == reservationId);

        return reservation; 
    }

    public async Task<List<Reservation>> GetOverlappingReservationsAsync(TimeOnly startTime, TimeOnly endTime)
    {
        return await _context.Reservations
            .Include(r => r.Table)
            .Where(r =>
                startTime < r.ReservationEndTime &&
                endTime > r.ReservationStartTime)
            .ToListAsync();
    }


    public async Task<int> CreateNewReservationAsync(Reservation reservation)
    { 
        await _context.Reservations.AddAsync(reservation);
        await _context.SaveChangesAsync();

        return reservation.Id;
    }

    public async Task<bool> UpdateReservationAsync(Reservation reservation)
    {

        _context.Reservations.Update(reservation);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteReservationAsync(int reservationId)
    {
        var rowsAffected = await _context.Reservations.Where(r => r.Id == reservationId).ExecuteDeleteAsync();

        if (rowsAffected > 0)
        {
            return true;
        }

        return false;
    }
}