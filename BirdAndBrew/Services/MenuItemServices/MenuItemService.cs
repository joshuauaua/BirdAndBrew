using BirdAndBrew.DTOs.MenuItemDTOs;
using BirdAndBrew.Models;
using BirdAndBrew.Repositories.MenuItemRepositories;

namespace BirdAndBrew.Services.MenuItemServices;

public class MenuItemService : IMenuItemService
{
    private readonly IMenuItemRepository _context;

    public MenuItemService(IMenuItemRepository context)
    {
        _context = context;
    }
    
    
    public async Task<int> CreateMenuItemAsync(MenuItemDTO menuItemDTO)
    {
        var menuItem = new MenuItem
        {
            Id = menuItemDTO.Id,
            Name = menuItemDTO.Name,
            Description = menuItemDTO.Description,
            Price = menuItemDTO.Price,
            Image = menuItemDTO.Image,
            IsPopular = menuItemDTO.IsPopular
        };

        await _context.CreateMenuItemAsync(menuItem);
        
        return menuItem.Id;
    }

    public async Task<List<MenuItemDTO>> GetMenuItemsAsync()
    {
        var menuItems = await _context.GetMenuItemsAsync();

        var menuItemDTO = menuItems.Select(m => new MenuItemDTO
        {
            Id = m.Id,
            Name = m.Name,
            Description = m.Description,
            Price = m.Price,
            Image = m.Image,
            IsPopular = m.IsPopular
        }).ToList();

        if (menuItemDTO == null)
        {
            return null;
        }

        return menuItemDTO;

    }

    public async Task<MenuItemDTO> GetMenuItemByIdAsync(int menuItemDTOId)
    {

        var menuItem = await _context.GetMenuItemByIdAsync(menuItemDTOId);

        if (menuItem == null)
        {
            return null;
        }

        var menuItemDTO = new MenuItemDTO()
        {
            Id = menuItem.Id,
            Name = menuItem.Name,
            Description = menuItem.Description,
            Price = menuItem.Price,
            Image = menuItem.Image,
            IsPopular = menuItem.IsPopular
        };

        return menuItemDTO;
    }

    public async Task<bool> UpdateMenuItemAsync(MenuItemDTO menuItemDTO)
    {
        var existing = await _context.GetMenuItemByIdAsync(menuItemDTO.Id);

        if (existing == null)
        {
            return false;
        }

        existing.Name = menuItemDTO.Name;
        existing.Description = menuItemDTO.Description;
        existing.Price = menuItemDTO.Price;
        existing.Image = menuItemDTO.Image;
        existing.IsPopular = menuItemDTO.IsPopular;
        
        await _context.UpdateMenuItemAsync(existing);

        return true;
    }

    public async Task<bool> DeleteMenuItemAsync(int menuItemId)
    {

        if (menuItemId == null)
        {
            return false;
        }

        await _context.DeleteMenuItemAsync(menuItemId);

        return true;

    }
}