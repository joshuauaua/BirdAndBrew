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
    public async Task <ActionResult<string>> Login(AdminDTO request)
    {
        var token = await authService.LoginAsync(request);

        if (token is null)
        {
            return BadRequest("Invalid username or password.");
        }
        
        return Ok(token);

    }


    [Authorize]
    [HttpGet]
    public IActionResult AuthenticatedOnlyEndpoint()
    {
        return Ok("You are authenticated!");
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("admin-only")]
    public IActionResult AdminOnlyEndpoint()
    {
        return Ok("You are an admin!");
    }
    
}