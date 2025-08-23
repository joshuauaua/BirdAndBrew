using BirdAndBrew.DTOs.CustomerDTOs;
using BirdAndBrew.Repositories.CustomerRepositories;

namespace BirdAndBrew.Services.CustomerServices;

public class CustomerService : ICustomerService
{
    
    //DI from repository
    
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    
    
    //Get All Customers
    public async Task<List<CustomerDTO>> GetAllCustomersAsync()
    {
        throw new NotImplementedException();
    }

    //Get All Customers by ID
    public Task<CustomerDTO> GetCustomerByIdAsync(int customerId)
    {
        throw new NotImplementedException();
    }

    //Add Customer Async
    public Task<int> AddCustomerAsync(CustomerDTO customerDTO)
    {
        throw new NotImplementedException();
    }

    //Update Customer Async
    public Task<bool> UpdateCustomerAsync(CustomerDTO customerDTO)
    {
        throw new NotImplementedException();
    }

    //Delete Customer
    public Task<bool> DeleteCustomerAsync(int customerId)
    {
        throw new NotImplementedException();
    }
}