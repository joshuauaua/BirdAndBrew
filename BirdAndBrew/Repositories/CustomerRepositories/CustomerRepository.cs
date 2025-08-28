using BirdAndBrew.Data;
using BirdAndBrew.Models;
using BirdAndBrew.Repositories.CustomerRepositories;
using Microsoft.EntityFrameworkCore;

namespace BirdAndBrew.Repositories;

public class CustomerRepository : ICustomerRepository
{
    
    //First off, DI (reference) the AbbDBContext
    private readonly AppDBContext _context;

    public CustomerRepository(AppDBContext context)
    {
        _context = context;
    }
    
    public async Task<List<Customer>> GetAllCustomersAsync()
    {

        var customers = await _context.Customers.ToListAsync();

        return customers;
    }
    

    public async Task<Customer> GetCustomerByIdAsync(int customerId)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
        
        return customer; 
    }

    public async Task<int> AddCustomerAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();

        return customer.Id;
    }
    
    
    public async Task<bool> UpdateCustomerAsync(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
        return true;
    }
    

    public async Task<bool> DeleteCustomerAsync(int customerId)
    {
        var rowsAffected = await _context.Customers.Where(c => c.Id == customerId).ExecuteDeleteAsync();

        if (rowsAffected > 0)
        {
            return true;
        }
        return false;
    }
}