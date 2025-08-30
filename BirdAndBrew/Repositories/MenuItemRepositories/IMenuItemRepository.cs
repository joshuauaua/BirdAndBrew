using BirdAndBrew.Models;

namespace BirdAndBrew.Repositories.MenuItemRepositories;

public interface IMenuItemRepository
{
    //Create Menu Item
    Task<int> CreateMenuItemAsync(MenuItem menuItem);

    //Get Menu Items
    Task<List<MenuItem>> GetMenuItemsAsync();

    // Read Menu Item By ID
    Task<MenuItem> GetMenuItemByIdAsync(int menuItemId);
    
    //Update Menu Item
    Task<bool> UpdateMenuItemAsync(MenuItem menuItem);

    //Delete Menu Item
    Task<bool> DeleteMenuItemAsync(int menuItemId);
    
}