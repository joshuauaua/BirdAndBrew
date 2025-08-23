using BirdAndBrew.Models;

namespace BirdAndBrew.Repositories.TableRepositories;

public interface ITableRepository
{
    
    //Get All Tables
    Task<List<Table>> GetAllTablesAsync();

    //Get Customer By Id
    Task<Table> GetTableByIdAsync(int tableId);
    
    //Add Customer
    Task<int> AddTableAsync(Table table);

    //Update Customer
    Task<bool> UpdateTableAsync(Table table);

    //Delete Customer
    Task<bool> DeleteTableAsync(int tableId);

}