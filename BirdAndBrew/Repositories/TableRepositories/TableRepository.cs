using BirdAndBrew.Data;
using BirdAndBrew.Models;
using Microsoft.EntityFrameworkCore;

namespace BirdAndBrew.Repositories.TableRepositories;

public class TableRepository : ITableRepository
{

    private readonly AppDBContext _context;

    public TableRepository(AppDBContext context)
    {
        _context = context;
    }
    
    public async Task<List<Table>> GetAllTablesAsync()
    {
        var tables = await _context.Tables.ToListAsync();
        
        return tables;
    }

    
    //Testing using FindAsync instead of FirstOrDefault
    public async Task<Table> GetTableByIdAsync(int tableId)
    {
        var selectedTable = await _context.Tables.FindAsync(tableId);
        return selectedTable;
    }
    
    
    public async Task<int> AddTableAsync(Table table)
    {
        _context.Tables.AddAsync(table);
        await _context.SaveChangesAsync();

        return table.Id;
    }

    public async Task<bool> UpdateTableAsync(Table table)
    {
         _context.Tables.Update(table);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteTableAsync(int tableId)
    {

        var rowsAffected = await _context.Tables.Where(t => t.Id == tableId).ExecuteDeleteAsync();

        if (rowsAffected > 0)
        {
            return true;
        }

        return false;
    }
}