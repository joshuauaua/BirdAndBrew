using BirdAndBrew.Models;

namespace BirdAndBrew.Repositories.TableRepositories;

public interface ITableRepository
{
    
    //Get All Tables
    Task<List<Table>> GetAllTablesAsync();

    //Get Table By Id
    Task<Table> GetTableByIdAsync(int tableId);
    
    
    //Add Table
    Task<int> AddTableAsync(Table table);

    //Update Table
    Task<bool> UpdateTableAsync(Table table);

    //Delete Table
    Task<bool> DeleteTableAsync(int tableId);

}