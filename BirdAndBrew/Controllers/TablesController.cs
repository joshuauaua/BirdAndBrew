using BirdAndBrew.DTOs.TableDTOs;
using BirdAndBrew.Services.TableServices;
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

    
    //Get All
    [HttpGet]
    public async Task<ActionResult<List<TableDTO>>> GetAllTables()
    {
        
        if (_tableService == null)
            throw new Exception("_tableService was not injected!");
        
        
        var tables = await _tableService.GetAllTablesAsync();

        return Ok(tables);

    }

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

    [HttpPost]
    public async Task<ActionResult<TableDTO>> AddTable(TableDTO tableDTO)
    {
        var tableId = _tableService.AddTableAsync(tableDTO);

        return CreatedAtAction(nameof(GetAllTables), new { Id = tableId });
    }

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



    [HttpDelete]

    public async Task<ActionResult<TableDTO>> DeleteTable(TableDTO tableDTO)
    {

        var deleted = await _tableService.DeleteTableAsync(tableDTO.Id);

        if (!deleted)
            return NotFound();

        return NoContent();
        
    }

}

