using BirdAndBrew.Data;
using BirdAndBrew.Models;
using BirdAndBrew.Repositories.CustomerRepositories;

namespace BirdAndBrew.Repositories;

public class CustomerRespository : ICustomerRepository
{
    
    
    //First off, DI (reference) the AbbDBContext
    private readonly AppDBContext _context;

    public CustomerRespository(AppDBContext context)
    {
        _context = context;
    }


    public Task<List<Customer>> GetAllCustomersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Customer> GetCustomerByIdAsync(int customerId)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddCustomerAsync(Customer customer)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateCustomerAsync(Customer customer)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUserAsync(int customerId)
    {
        throw new NotImplementedException();
    }
}