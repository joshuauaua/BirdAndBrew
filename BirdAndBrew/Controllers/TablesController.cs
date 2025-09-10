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

    
    [Authorize (Roles = "Admin")]
    //Get All
    [HttpGet]
    public async Task<ActionResult<List<TableDTO>>> GetAllTables()
    {
        
        var tables = await _tableService.GetAllTablesAsync();

        return Ok(tables);

    }
    
    [Authorize (Roles = "Admin")]
    [HttpGet("{id:int}")]
    
    public async Task<ActionResult<TableDTO>> GetTableById(int id)
    {
        var table = await _tableService.GetTableByIdAsync(id);

        if (table == null)
        {

            return NotFound();
        }

        return Ok(table);
    }
    
    [Authorize (Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<TableDTO>> AddTable(TableDTO tableDTO)
    {
        var tableId = _tableService.AddTableAsync(tableDTO);

        return CreatedAtAction(nameof(GetAllTables), new { Id = tableId });
    }

    [Authorize (Roles = "Admin")]
    [HttpPut]
    public async Task<ActionResult<TableDTO>> UpdateTable(TableDTO tableDTO)
    {
        var updated = await _tableService.UpdateTableAsync(tableDTO);

        if (!updated)
        {
            return NotFound();
        }

        return Ok(tableDTO.Id);
    }

    [Authorize (Roles = "Admin")]
    [HttpPatch]
    public async Task<ActionResult<TableDTO>> UpdateTableField(TableDTO tableDTO)
    {
        var updated = await _tableService.UpdateTableFieldAsync(tableDTO);

        if (!updated)
        {
            return NotFound();
        }

        return Ok(tableDTO.Id);
        
    }


    [Authorize (Roles = "Admin")]
    [HttpDelete]

    public async Task<ActionResult<TableDTO>> DeleteTable(int id)
    {

        var deleted = await _tableService.DeleteTableAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
        
    }
    
    
    

}

