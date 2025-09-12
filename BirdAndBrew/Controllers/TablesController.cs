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

    
    //[Authorize (Roles = "Admin")]
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
    [HttpPut]
    public async Task<ActionResult<ReadTableDTO>> UpdateTable(ReadTableDTO readTableDTO)
    {
        var updated = await _tableService.UpdateTableAsync(readTableDTO);

        if (!updated)
        {
            return NotFound();
        }

        return Ok(readTableDTO.Id);
    }

    //[Authorize (Roles = "Admin")]
    [HttpPatch]
    public async Task<ActionResult<ReadTableDTO>> UpdateTableField(ReadTableDTO readTableDTO)
    {
        var updated = await _tableService.UpdateTableFieldAsync(readTableDTO);

        if (!updated)
        {
            return NotFound();
        }

        return Ok(readTableDTO.Id);
        
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

