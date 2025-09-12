using BirdAndBrew.Data;
using BirdAndBrew.Models;
using Microsoft.EntityFrameworkCore;

namespace BirdAndBrew.Services.BookingAvailabilityServices;

public class BookingAvailabilityService : IBookingAvailabilityService
{
    private readonly AppDBContext _context;

    public BookingAvailabilityService(AppDBContext context)
    {
        _context = context;
    }

    public async Task<List<Table>> GetAvailableTablesAsync(TimeOnly startTime, int partySize)
    {
        var endTime = startTime.AddHours(2);

        // Get IDs of tables that are already booked in the time range
        var bookedTableIds = await _context.Reservations
            .Where(r => startTime < r.ReservationEndTime && endTime > r.ReservationStartTime)
            .Select(r => r.Fk_TableId)
            .Distinct()
            .ToListAsync();

        // Get tables that are not booked and have sufficient capacity
        var availableTables = await _context.Tables
            .Where(t => t.Capacity >= partySize && !bookedTableIds.Contains(t.Id))
            .ToListAsync();

        return availableTables;
    }

    
}