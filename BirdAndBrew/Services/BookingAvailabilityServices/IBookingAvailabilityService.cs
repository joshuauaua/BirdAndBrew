using BirdAndBrew.Models;

namespace BirdAndBrew.Services.BookingAvailabilityServices;

public interface IBookingAvailabilityService
{
           Task<List<Table>> GetAvailableTablesAsync(DateOnly date, TimeOnly startTime, int partySize);
}