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
    
    public async Task<List<ReadTableDTO>> GetAllTablesAsync()
    {
        var tables = await _tableRepository.GetAllTablesAsync();

        var tablesDTO = tables.Select(t => new ReadTableDTO
        {
            Id = t.Id,
            TableNumber = t.TableNumber,
            Capacity = t.Capacity
        }).ToList();

        return tablesDTO;
    }

    public async Task<ReadTableDTO> GetTableByIdAsync(int tableId)
    {
        var table = await _tableRepository.GetTableByIdAsync(tableId);

        if (table == null)
        {
            return null;
        }
        
        var tableDTO = new ReadTableDTO
        {
            Id = table.Id,
            TableNumber = table.TableNumber,
            Capacity = table.Capacity
        };
        
        return tableDTO;
    }


    public async Task<int> AddTableAsync(CreateTableDTO createTableDTO)
    {
        
        var table = new Table
        {
            TableNumber = createTableDTO.TableNumber,
            Capacity = createTableDTO.Capacity
        };

        var tableId = await _tableRepository.AddTableAsync(table);

        return tableId;
    }
    
    
    public async Task<bool> UpdateTableAsync(int Id, CreateTableDTO tableDTO)
    {
        var existing = await _tableRepository.GetTableByIdAsync(Id);

        if (existing == null)
        {
            return false;
        }
        
        existing.TableNumber = tableDTO.TableNumber;
        existing.Capacity = tableDTO.Capacity;
        
        await _tableRepository.UpdateTableAsync(existing);

        return true;
    }
    
    
    public async Task<bool> DeleteTableAsync(int tableId)
    {
        await _tableRepository.GetTableByIdAsync(tableId);

        if (tableId == 0)
        {
            return false;
        }
        
        await _tableRepository.DeleteTableAsync(tableId);
        
        return true;
        
    }
}