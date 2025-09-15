namespace BirdAndBrew.DTOs.MenuItemDTOs;

public class CreateMenuItemDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string? Image { get; set; }
    public bool IsPopular { get; set; }
}