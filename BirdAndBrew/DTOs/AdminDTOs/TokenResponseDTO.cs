namespace BirdAndBrew.DTOs.AdminDTOs;

public class TokenResponseDTO
{
    public required string AccessToken { get; set; }
    public required string RefreshToken { get; set; }
}