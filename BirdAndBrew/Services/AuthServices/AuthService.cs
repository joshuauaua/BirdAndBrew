using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BirdAndBrew.Data;
using BirdAndBrew.DTOs.AdminDTOs;
using BirdAndBrew.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BirdAndBrew.Services.AdminServices;

public class AuthService : IAuthService
{

    private readonly AppDBContext _context;
    private readonly IConfiguration _configuration;

    public AuthService(AppDBContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }


    public async Task<Admin> RegisterAsync(AdminDTO request)
    {

        if (await _context.Admins.AnyAsync(a => a.UserName == request.UserName))
        {
            return null;
        }

        var admin = new Admin();
        
        var hashedPassword = new PasswordHasher<Admin>()
            .HashPassword(admin, request.Password);

        admin.UserName = request.UserName;
        admin.Password = hashedPassword;

        _context.Admins.Add(admin);
        await _context.SaveChangesAsync();
        
        return admin;
    }

    public async Task<string> LoginAsync(AdminDTO request)
    {

        var admin = await _context.Admins.FirstOrDefaultAsync(a => a.UserName == request.UserName);

        if (admin == null)
        {
            return null;
        }
        

        if (new PasswordHasher<Admin>().VerifyHashedPassword(admin, admin.Password, request.Password) == PasswordVerificationResult.Failed)
        {
            return null;
        }


        return CreateToken(admin);

    }
    
    private string CreateToken(Admin admin)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, admin.UserName),
            new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()),
            new Claim(ClaimTypes.Role, admin.Role)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:Token")!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var tokenDescriptor = new JwtSecurityToken(
            issuer: _configuration.GetValue<string>("AppSettings:Issuer"),
            audience: _configuration.GetValue<string>("AppSettings:Audience"),
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }

    
    
}