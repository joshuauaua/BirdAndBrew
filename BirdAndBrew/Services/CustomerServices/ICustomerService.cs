using BirdAndBrew.DTOs.CustomerDTOs;

namespace BirdAndBrew.Services.CustomerServices;

public interface ICustomerService
{
    
    //Get All Customers
    Task<List<CustomerDTO>> GetAllCustomersAsync();

    //Get Customer By Id
    Task<CustomerDTO> GetCustomerByIdAsync(int customerId);
    
    //Add Customer
    Task<int> AddCustomerAsync(CustomerDTO customerDTO);

    //Update Customer
    Task<bool> UpdateCustomerAsync(CustomerDTO customerDTO);

    //Delete Customer
    Task<bool> DeleteCustomerAsync(int customerId);

}
