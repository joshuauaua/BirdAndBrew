using BirdAndBrew.DTOs.MenuItemDTOs;

namespace BirdAndBrew.Services.MenuItemServices;

public interface IMenuItemService
{
    //Create Menu Item
    Task<int> CreateMenuItemAsync(MenuItemDTO menuItemDTO);

    //Get Menu Items
    Task<List<MenuItemDTO>> GetMenuItemsAsync();

    // Read Menu Item By ID
    Task<MenuItemDTO> GetMenuItemByIdAsync(int menuItemDTOId);
    
    //Update Menu Item
    Task<bool> UpdateMenuItemAsync(MenuItemDTO menuItemDTO);

    //Delete Menu Item
    Task<bool> DeleteMenuItemAsync(int menuItemId);

}