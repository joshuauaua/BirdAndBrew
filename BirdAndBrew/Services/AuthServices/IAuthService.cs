using BirdAndBrew.DTOs.AdminDTOs;
using BirdAndBrew.Models;

namespace BirdAndBrew.Services.AdminServices;

public interface IAuthService
{

    Task<Admin> RegisterAsync(AdminDTO request);
    
    Task<string> LoginAsync(AdminDTO request);

    
}