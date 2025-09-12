using BirdAndBrew.DTOs.MenuItemDTOs;
using BirdAndBrew.Services.MenuItemServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BirdAndBrew.Controllers;

[Route("api/menuitem")]
[ApiController]

public class MenuItemsController : ControllerBase
{

    private readonly IMenuItemService _menuItemService;

    public MenuItemsController(IMenuItemService menuItemService)
    {
        _menuItemService =  menuItemService;
    }
    
    //[Authorize (Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<int>> CreateNewMenuItem(MenuItemDTO menuItemDTO)
    {
        await _menuItemService.CreateMenuItemAsync(menuItemDTO);

        if (menuItemDTO == null)
        {
            return NotFound();
        }
        return Ok(menuItemDTO.Id);
    }

    [HttpGet]
    public async Task<ActionResult<List<MenuItemDTO>>> GetMenuItems()
    {
        var menuItems = await _menuItemService.GetMenuItemsAsync();

        return Ok(menuItems);
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<MenuItemDTO>> GetMenuItemsById(int id)
    {
        var menuItemDTO = await _menuItemService.GetMenuItemByIdAsync(id);

        if (menuItemDTO == null)
        {
            return NotFound();
        }

        return Ok(menuItemDTO);
    }
    
    
    

    //[Authorize (Roles = "Admin")]
    [HttpPut]
    public async Task<ActionResult<MenuItemDTO>> UpdateMenuItem(MenuItemDTO menuItemDTO)
    {

        var updated = _menuItemService.UpdateMenuItemAsync(menuItemDTO);

        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok(menuItemDTO.Id);
        
    }

    //[Authorize (Roles = "Admin")]
    [HttpDelete]
    public async Task<ActionResult<MenuItemDTO>> DeleteMenuItem(int id)
    {
        var deleted = await _menuItemService.DeleteMenuItemAsync(id);

        if (!deleted)
            return NotFound();
        
        return NoContent();

    }
    


}