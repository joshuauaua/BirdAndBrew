using BirdAndBrew.DTOs.ReservationDTOs;
using BirdAndBrew.DTOs.TableDTOs;
using BirdAndBrew.Models;

namespace BirdAndBrew.Services.TableServices;

public interface ITableService
{
    //Get All Tables
    Task<List<ReadTableDTO>> GetAllTablesAsync();

    //Get Table By Id
    Task<ReadTableDTO> GetTableByIdAsync(int tableDTOId);
    
    
    //Add Table
    Task<int> AddTableAsync(CreateTableDTO createTableDTO);

    //Update Table
    Task<bool> UpdateTableAsync(int id, CreateTableDTO tableDTO);
    
    //Delete Table
    Task<bool> DeleteTableAsync(int tableId);

}