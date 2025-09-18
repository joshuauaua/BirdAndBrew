using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BirdAndBrew.Data;
using BirdAndBrew.DTOs.UserDTOs;
using BirdAndBrew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace BirdAndBrew.Controllers;


[Route("api/auth")]
[ApiController]

public class AuthController : ControllerBase
{


    private readonly AppDBContext _context;
    private readonly IConfiguration _config;
    public AuthController(AppDBContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }


    [HttpPost("Register")]
    public async Task<IActionResult> Register(UserRegisterDTO newUser)
    {

        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == newUser.Email);

        if (existingUser != null)
        {
            return BadRequest("Email is already in use");
        }

        string passwordHash = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

        var newAccount = new User
        {
            FirstName = newUser.FirstName,
            LastName = newUser.LastName,
            Email = newUser.Email,
            Role = "Admin",
            PasswordHash = passwordHash
        };
        
        _context.Users.Add(newAccount);
        _context.SaveChanges();
        
        return Ok();
    }
    
    
    [HttpPost("Login")]
    public async Task<IActionResult> Login(UserLoginDTO loginUser)
    {
        
        //CHECK IF EMAIL MATCHES
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginUser.Email);
        if (user == null)
        {
            return Unauthorized("Invalid email or password");
        }
        
        //CHECK IF PASSWORD MATCHES
        bool passwordMatch = BCrypt.Net.BCrypt.Verify(loginUser.Password, user.PasswordHash);

        if (!passwordMatch)
        {
            return Unauthorized("Invalid email or password");
        }

        var token = GenerateJwtToken(user);
        
        
        return Ok( new { token });
    }


    private string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);

        var claims = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(ClaimTypes.Email, user.Email)
        });
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claims,
            Expires = DateTime.UtcNow.AddHours(1),
            Issuer = _config["Jwt:Issuer"],
            Audience = _config["Jwt:Audience"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    

}