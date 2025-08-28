using BirdAndBrew.DTOs.ReservationDTOs;
using BirdAndBrew.Services.BookingAvailabilityServices;
using BirdAndBrew.Services.ReservationServices;
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
    
    

    

    
    [HttpGet]
    public async Task<ActionResult<List<ReservationDTO>>> GetAllReservations()
    {
        var reservations = await _context.GetAllReservationsAsync();
        
        return Ok(reservations);
    }
    

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ReservationDTO>> GetReservationById(int id)
    {
        var reservation = await _context.GetReservationByIdAsync(id);

        if (reservation == null)
        {
            return NotFound();
        }
        
        return Ok(reservation);
    }

    
    //Available Tables
    [HttpGet("available-tables")]
    public async Task<IActionResult> GetAvailableTables(DateTime startTime, int partySize)
    {
        var tables = await _bookingAvailability.GetAvailableTablesAsync(startTime, partySize);

        if (!tables.Any())
            return NotFound("No available tables.");

        return Ok(tables);
    }

    
    
    [HttpPost]
    public async Task<ActionResult<ReservationDTO>> CreateReservation(ReservationDTO reservationDTO)
    {

        var reservationId = await _context.CreateNewReservationAsync(reservationDTO);

        return CreatedAtAction(nameof(GetAllReservations), new { id = reservationId });
    }

    [HttpPut]
    public async Task<ActionResult<ReservationDTO>> UpdateReservation(ReservationDTO reservationDTO)
    {

        var updated = await _context.UpdateReservationAsync(reservationDTO);

        if (!updated)
        {
            return NotFound();
        }
        return Ok(reservationDTO.Id);
    }

    [HttpPatch]
    public async Task<ActionResult<ReservationDTO>> UpdateReservationField(ReservationDTO reservationDTO)
    {
        var updated = await _context.UpdateReservationFieldAsync(reservationDTO);

        if (!updated)
        {
            return NotFound();
        }

        return Ok(reservationDTO.Id);

    }
    
    [HttpDelete]

    public async Task<ActionResult<ReservationDTO>> DeleteReservation(ReservationDTO reservationDTO)
    {
        var deleted = await _context.DeleteReservationAsync(reservationDTO.Id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    } 
    
    
}
