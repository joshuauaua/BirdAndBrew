using BirdAndBrew.DTOs.ReservationDTOs;
using BirdAndBrew.DTOs.TableDTOs;
using BirdAndBrew.Models;
using BirdAndBrew.Repositories.ReservationRepositories;
using BirdAndBrew.Repositories.TableRepositories;


namespace BirdAndBrew.Services.TableServices;

public class TableService : ITableService
{

     private readonly ITableRepository _tableRepository;
     
    public TableService(ITableRepository tableRepository)
    {
        _tableRepository = tableRepository;
    }
    
    public async Task<List<TableDTO>> GetAllTablesAsync()
    {
        var tables = await _tableRepository.GetAllTablesAsync();

        var tablesDTO = tables.Select(t => new TableDTO
        {
            Id = t.Id,
            TableNumber = t.TableNumber,
            Capacity = t.Capacity
        }).ToList();

        return tablesDTO;
    }

    public async Task<TableDTO> GetTableByIdAsync(int tableId)
    {
        var table = await _tableRepository.GetTableByIdAsync(tableId);

        if (table == null)
        {
            return null;
        }
        
        var tableDTO = new TableDTO
        {
            Id = table.Id,
            TableNumber = table.TableNumber,
            Capacity = table.Capacity
        };
        
        return tableDTO;
    }


    public async Task<int> AddTableAsync(TableDTO tableDTO)
    {
        
        var table = new Table
        {
            Id = tableDTO.Id,
            TableNumber = tableDTO.TableNumber,
            Capacity = tableDTO.Capacity
        };

        var tableId = await _tableRepository.AddTableAsync(table);

        return tableId;
    }
    
    
    public async Task<bool> UpdateTableAsync(TableDTO tableDTO)
    {
        var updatedTable = await _tableRepository.GetTableByIdAsync(tableDTO.Id);

        if (tableDTO == null)
        {
            return false;
        }
        updatedTable.TableNumber = tableDTO.TableNumber;
        updatedTable.Capacity = tableDTO.Capacity;
        
        await _tableRepository.UpdateTableAsync(updatedTable);

        return true;
    }

    public async Task<bool> UpdateTableFieldAsync(TableDTO tableDTO)
    {
        var existing = await _tableRepository.GetTableByIdAsync(tableDTO.Id);
        
        if (existing == null)
        {
            return false;
        }
        if (tableDTO.TableNumber != null)
            existing.TableNumber = tableDTO.TableNumber;
        
        if (tableDTO.Capacity != null)
            existing.Capacity = tableDTO.Capacity;
        
        _tableRepository.UpdateTableAsync(existing);
        
        return true;
    }
    

    
    
    public async Task<bool> DeleteTableAsync(int tableId)
    {
        await _tableRepository.GetTableByIdAsync(tableId);

        if (tableId == null)
        {
            return false;
        }

        _tableRepository.DeleteTableAsync(tableId);
        
        return true;
        
    }
}