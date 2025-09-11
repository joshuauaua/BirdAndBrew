using BirdAndBrew.Models;

namespace BirdAndBrew.DTOs.CustomerDTOs;

public class CustomerDTO
{
    public int Id { get; set; } 
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }

    public string PhoneNumber { get; set; }
}