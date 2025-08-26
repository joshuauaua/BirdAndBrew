using BirdAndBrew.DTOs.TableDTOs;

namespace BirdAndBrew.Services.TableServices;

public interface ITableService
{
    //Get All Tables
    Task<List<TableDTO>> GetAllTablesAsync();

    //Get Customer By Id
    Task<TableDTO> GetTableByIdAsync(int tableDTOId);
    
    //Add Customer
    Task<int> AddTableAsync(TableDTO tableDTO);

    //Update Customer
    Task<bool> UpdateTableAsync(TableDTO tableDTO);
    
    //Update Customer Field

    Task<bool> UpdateTableFieldAsync(TableDTO tableDTO);

    //Delete Customer
    Task<bool> DeleteTableAsync(int tableId);

}