using BirdAndBrew.DTOs.AdminDTOs;
using BirdAndBrew.Models;
using BirdAndBrew.Services.AdminServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BirdAndBrew.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AuthController(IAuthService authService) : ControllerBase
{
    
    [HttpPost("register")]
    public async Task<ActionResult<Admin>> Register(AdminDTO request)
    {
        var admin = await authService.RegisterAsync(request);

        if (admin is null)
        {
            return BadRequest("Username already exists");
        }
        
        return Ok(admin);
    }


    [HttpPost("login")]
    public async Task <ActionResult<TokenResponseDTO>> Login(AdminDTO request)
    {
        var result = await authService.LoginAsync(request);

        if (result is null)
        {
            return BadRequest("Invalid username or password.");
        }
        
        return Ok(result);

    }
    
}