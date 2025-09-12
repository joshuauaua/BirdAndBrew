using BirdAndBrew.Models;

namespace BirdAndBrew.Services.BookingAvailabilityServices;

public interface IBookingAvailabilityService
{
           Task<List<Table>> GetAvailableTablesAsync(DateTime startTime, int partySize);
}