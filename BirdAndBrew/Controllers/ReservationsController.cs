using BirdAndBrew.DTOs.ReservationDTOs;
using BirdAndBrew.Services.BookingAvailabilityServices;
using BirdAndBrew.Services.ReservationServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BirdAndBrew.Controllers;

[Route("api/reservations")]
[ApiController]

public class ReservationsController : ControllerBase
{
    private readonly IReservationService _context;
    private readonly IBookingAvailabilityService _bookingAvailability;
    
    public ReservationsController(IReservationService context, IBookingAvailabilityService bookingAvailability)
    {
        _context = context;
        _bookingAvailability = bookingAvailability;

    }
    

    //[Authorize (Roles = "Admin")]
    [HttpGet]
    public async Task<ActionResult<List<ReadReservationDTO>>> GetAllReservations()
    {
        var reservations = await _context.GetAllReservationsAsync();
        
        return Ok(reservations);
    }
    
    //[Authorize (Roles = "Admin")]
    
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<CreateReservationDTO>> GetReservationById(int id)
    {
        var reservation = await _context.GetReservationByIdAsync(id);

        if (reservation == null)
        {
            return NotFound();
        }
        
        return Ok(reservation);
    }

    //[Authorize (Roles = "Admin")]
    //Available Tables
    [HttpGet("available-tables")]
    public async Task<IActionResult> GetAvailableTables(DateOnly date, TimeOnly startTime, int partySize)
    {
        var tables = await _bookingAvailability.GetAvailableTablesAsync(date, startTime, partySize);

        if (!tables.Any())
            return NotFound("No available tables.");

        return Ok(tables);
    }

    
   //[Authorize (Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<CreateReservationDTO>> CreateReservation(CreateReservationDTO createReservationDTO)
    {

        var reservationId = await _context.CreateReservationAsync(createReservationDTO);

        return CreatedAtAction(nameof(GetAllReservations), new { id = reservationId });
    }

    //[Authorize (Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<ActionResult<CreateReservationDTO>> UpdateReservation(int id, [FromBody] CreateReservationDTO reservationDTO)
    {

        var updated = await _context.UpdateReservationAsync(id, reservationDTO);

        if (!updated)
        {
            return NotFound();
        }
        return Ok(reservationDTO);
    }
    
    
    
    //[Authorize (Roles = "Admin")]
    [HttpDelete]

    public async Task<ActionResult<CreateReservationDTO>> DeleteReservation(int id)
    {
        var deleted = await _context.DeleteReservationAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    } 
    
    
    

    
}
