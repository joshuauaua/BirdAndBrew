using BirdAndBrew.DTOs.ReservationDTOs;
using BirdAndBrew.DTOs.TableDTOs;
using BirdAndBrew.Models;
using BirdAndBrew.Services.TableServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BirdAndBrew.Controllers;

[Route("api/tables")]
[ApiController]

public class TablesController : ControllerBase
{
    
    private readonly ITableService _tableService;

    public TablesController(ITableService tableService)
    {
         _tableService = tableService;
    }

    
    //[Authorize]
    //Get All
    [HttpGet]
    public async Task<ActionResult<List<ReadTableDTO>>> GetAllTables()
    {
        
        var tables = await _tableService.GetAllTablesAsync();

        return Ok(tables);

    }
    
    //[Authorize (Roles = "Admin")]
    [HttpGet("{id:int}")]
    
    public async Task<ActionResult<ReadTableDTO>> GetTableById(int id)
    {
        var table = await _tableService.GetTableByIdAsync(id);

        if (table == null)
        {

            return NotFound();
        }

        return Ok(table);
    }
    
    //[Authorize (Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<ReadTableDTO>> AddTable(CreateTableDTO createTableDTO)
    {
        var tableId = _tableService.AddTableAsync(createTableDTO);

        return CreatedAtAction(nameof(GetAllTables), new { Id = tableId });
    }

    //[Authorize (Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<ActionResult<ReadTableDTO>> UpdateTable(int id, [FromBody] CreateTableDTO tableDTO)
    {
        var updated = await _tableService.UpdateTableAsync(id, tableDTO);

        if (!updated)
        {
            return NotFound();
        }

        return Ok(tableDTO);
    }
    

    //[Authorize (Roles = "Admin")]
    [HttpDelete]
    public async Task<ActionResult<ReadTableDTO>> DeleteTable(int id)
    {

        var deleted = await _tableService.DeleteTableAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
        
    }
    
}

