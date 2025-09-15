using BirdAndBrew.DTOs.MenuItemDTOs;

namespace BirdAndBrew.Services.MenuItemServices;

public interface IMenuItemService
{
    //Create Menu Item
    Task<int> CreateMenuItemAsync(CreateMenuItemDTO menuItemDTO);

    //Get Menu Items
    Task<List<ReadMenuItemDTO>> GetMenuItemsAsync();

    // Read Menu Item By ID
    Task<ReadMenuItemDTO> GetMenuItemByIdAsync(int menuItemDTOId);
    
    //Update Menu Item
    Task<bool> UpdateMenuItemAsync(int id, CreateMenuItemDTO menuItemDTO);

    //Delete Menu Item
    Task<bool> DeleteMenuItemAsync(int menuItemId);

}