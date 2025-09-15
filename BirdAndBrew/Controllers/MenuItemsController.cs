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
    public async Task<ActionResult<int>> CreateNewMenuItem(CreateMenuItemDTO menuItemDTO)
    {
        await _menuItemService.CreateMenuItemAsync(menuItemDTO);

        if (menuItemDTO == null)
        {
            return NotFound();
        }
        return Ok(menuItemDTO);
    }

    [HttpGet]
    public async Task<ActionResult<List<ReadMenuItemDTO>>> GetMenuItems()
    {
        var menuItems = await _menuItemService.GetMenuItemsAsync();

        return Ok(menuItems);
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<ReadMenuItemDTO>> GetMenuItemsById(int id)
    {
        var menuItemDTO = await _menuItemService.GetMenuItemByIdAsync(id);

        if (menuItemDTO == null)
        {
            return NotFound();
        }

        return Ok(menuItemDTO);
    }
    
    
    

    //[Authorize (Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<ActionResult<ReadMenuItemDTO>> UpdateMenuItem(int id, [FromBody] CreateMenuItemDTO menuItemDTO)
    {

        var updated = await _menuItemService.UpdateMenuItemAsync(id, menuItemDTO);

        if (!updated)
        {
            return NotFound();
        }
        
        return Ok(updated);
        
    }

    //[Authorize (Roles = "Admin")]
    [HttpDelete]
    public async Task<ActionResult<ReadMenuItemDTO>> DeleteMenuItem(int id)
    {
        var deleted = await _menuItemService.DeleteMenuItemAsync(id);

        if (!deleted)
            return NotFound();
        
        return NoContent();

    }
    


}