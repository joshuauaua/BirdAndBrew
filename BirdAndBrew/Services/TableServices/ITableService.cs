using BirdAndBrew.DTOs.ReservationDTOs;
using BirdAndBrew.DTOs.TableDTOs;
using BirdAndBrew.Models;

namespace BirdAndBrew.Services.TableServices;

public interface ITableService
{
    //Get All Tables
    Task<List<TableDTO>> GetAllTablesAsync();

    //Get Table By Id
    Task<TableDTO> GetTableByIdAsync(int tableDTOId);
    
    
    //Add Table
    Task<int> AddTableAsync(TableDTO tableDTO);

    //Update Table
    Task<bool> UpdateTableAsync(TableDTO tableDTO);
    
    //Update Table Field

    Task<bool> UpdateTableFieldAsync(TableDTO tableDTO);

    //Delete Table
    Task<bool> DeleteTableAsync(int tableId);

}