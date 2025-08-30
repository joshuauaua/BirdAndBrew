using BirdAndBrew.Data;
using BirdAndBrew.Models;
using Microsoft.EntityFrameworkCore;

namespace BirdAndBrew.Repositories.MenuItemRepositories;


public class MenuItemRepository : IMenuItemRepository
{

    private readonly AppDBContext _context;

    public MenuItemRepository(AppDBContext context)
    {
        _context = context;
    }
    

    public async Task<int> CreateMenuItemAsync(MenuItem menuItem)
    {

        await _context.MenuItems.AddAsync(menuItem);
        await _context.SaveChangesAsync();

        return menuItem.Id;
    }

    public async Task<List<MenuItem>> GetMenuItemsAsync()
    {
        var menuItems= await _context.MenuItems.ToListAsync();

        return menuItems;
    }

    public async Task<MenuItem> GetMenuItemByIdAsync(int menuItemId)
    {
        var menuItem = await _context.MenuItems.FirstOrDefaultAsync(m => m.Id == menuItemId);

        return menuItem;
    }

    public async Task<bool> UpdateMenuItemAsync(MenuItem menuItem)
    {
        _context.MenuItems.Update(menuItem);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteMenuItemAsync(int menuItemId)
    {

        var rowsAffected = await _context.MenuItems.Where(m => m.Id == menuItemId).ExecuteDeleteAsync();

        if (rowsAffected == null)
        {
            return false;
        }

        return true;


    }
}