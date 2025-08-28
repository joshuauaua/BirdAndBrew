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
    public async Task<List<CustomerDTO>> GetAllCustomersAsync()
    {
        var customers = await _customerRepository.GetAllCustomersAsync();
        
        var customersDTO = customers.Select(c => new CustomerDTO
            {
                Id =c.Id,
                Name = c.Name,
                PhoneNumber = c.PhoneNumber
            }
        ).ToList();

        return customersDTO;
    }

    //Get All Customers by ID
    public async Task<CustomerDTO> GetCustomerByIdAsync(int customerId)
    {
        var customer = await _customerRepository.GetCustomerByIdAsync(customerId);

        if (customer == null)
        {
            return null;
        }
        
        var customerDTO = new CustomerDTO
        {
            Id = customer.Id,
            Name = customer.Name,
            PhoneNumber = customer.PhoneNumber
        };

        return customerDTO;
    }

    //Add Customer Async
    public async Task<int> AddCustomerAsync(CustomerDTO customerDTO)
    {
        var customer = new Customer
        {
            Name = customerDTO.Name,
            PhoneNumber = customerDTO.PhoneNumber
        };

        var newCustomerId = await _customerRepository.AddCustomerAsync(customer);
        
        return newCustomerId;
        
    }

    //Update Customer Async All Fields
    public async Task<bool> UpdateCustomerAsync(CustomerDTO customerDTO)
    {
        var existing = await _customerRepository.GetCustomerByIdAsync(customerDTO.Id);
        
        if (existing == null)
            return false;

        existing.Name = customerDTO.Name;
        existing.PhoneNumber = customerDTO.PhoneNumber;

        await _customerRepository.UpdateCustomerAsync(existing);

        return true;
    }
    
    
    //Update Customer Field Async 
    public async Task<bool> UpdateCustomerFieldAsync(CustomerDTO customerDTO)
    {
        var existing = await _customerRepository.GetCustomerByIdAsync(customerDTO.Id);
        
        if (existing == null)
            return false;

        if (customerDTO.Name != null)
            existing.Name = customerDTO.Name;
        
        if (customerDTO.PhoneNumber != null)
            existing.PhoneNumber = customerDTO.PhoneNumber;

        _customerRepository.UpdateCustomerAsync(existing);

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