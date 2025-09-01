using BirdAndBrew.DTOs.AdminDTOs;
using BirdAndBrew.Models;

namespace BirdAndBrew.Services.AdminServices;

public interface IAuthService
{

    Task<Admin> RegisterAsync(AdminDTO request);
    
    Task<TokenResponseDTO> LoginAsync(AdminDTO request);

    
}