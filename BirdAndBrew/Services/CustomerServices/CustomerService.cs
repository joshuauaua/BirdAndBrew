using BirdAndBrew.DTOs.CustomerDTOs;
using BirdAndBrew.Models;
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
    public async Task<List<ReadCustomerDTO>> GetAllCustomersAsync()
    {
        var customers = await _customerRepository.GetAllCustomersAsync();
        
        var customersDTO = customers.Select(c => new ReadCustomerDTO
            {
                Id =c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                PhoneNumber = c.PhoneNumber,
                EmailAddress = c.EmailAddress
            }
        ).ToList();

        return customersDTO;
    }

    //Get  Customers by ID
    public async Task<ReadCustomerDTO> GetCustomerByIdAsync(int id)
    {
        var customer = await _customerRepository.GetCustomerByIdAsync(id);

        if (customer == null)
        {
            return null;
        }
        
        var customerDTO = new ReadCustomerDTO
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber = customer.PhoneNumber,
            EmailAddress = customer.EmailAddress
        };

        return customerDTO;
    }

    //Add Customer Async
    public async Task<int> AddCustomerAsync(CreateCustomerDTO createCustomerDTO)
    {
        var customer = new Customer
        {
            FirstName = createCustomerDTO.FirstName,
            LastName = createCustomerDTO.LastName,
            PhoneNumber = createCustomerDTO.PhoneNumber,
            EmailAddress = createCustomerDTO.EmailAddress
        };

        var newCustomerId = await _customerRepository.AddCustomerAsync(customer);
        
        return newCustomerId;
        
    }

    //Update Customer Async All Fields
    public async Task<bool> UpdateCustomerAsync(int id, CreateCustomerDTO customerDTO)
    {
        var existing = await _customerRepository.GetCustomerByIdAsync(id);
        
        if (existing == null)
            return false;

        existing.FirstName = customerDTO.FirstName;
        existing.LastName = customerDTO.LastName;
        existing.PhoneNumber = customerDTO.PhoneNumber;
        existing.EmailAddress = customerDTO.EmailAddress;

        await _customerRepository.UpdateCustomerAsync(existing);

        return true;
    }
    
    //Delete Customer
    public async Task<bool> DeleteCustomerAsync(int customerId)
    {
        
        if (customerId == null)
        {
            return false;
        }
        
        await _customerRepository.DeleteCustomerAsync(customerId);

        return true;

    }
}