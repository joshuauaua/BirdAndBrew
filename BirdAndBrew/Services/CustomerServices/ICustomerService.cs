using BirdAndBrew.DTOs.CustomerDTOs;

namespace BirdAndBrew.Services.CustomerServices;

public interface ICustomerService
{
    
    //Get All Customers
    Task<List<ReadCustomerDTO>> GetAllCustomersAsync();

    //Get Customer By Id
    Task<ReadCustomerDTO> GetCustomerByIdAsync(int customerId);
    
    //Add Customer
    Task<int> AddCustomerAsync(CreateCustomerDTO createCustomerDTO);

    //Update Customer
    Task<bool> UpdateCustomerAsync(int id, CreateCustomerDTO customerDTO);
    
    //Delete Customer
    Task<bool> DeleteCustomerAsync(int customerId);

}
