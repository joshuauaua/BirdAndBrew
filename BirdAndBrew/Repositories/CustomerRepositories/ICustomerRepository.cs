using BirdAndBrew.Data;
using BirdAndBrew.Models;

namespace BirdAndBrew.Repositories.CustomerRepositories;

public interface ICustomerRepository
{
    
    //Get All Customers
    Task<List<Customer>> GetAllCustomersAsync();

    //Get Customer By Id
    Task<Customer> GetCustomerByIdAsync(int customerId);
    
    //Add Customer
    Task<int> AddCustomerAsync(Customer customer);

    //Update Customer
    Task<bool> UpdateCustomerAsync(Customer customer);
    
    //Delete Customer
    Task<bool> DeleteCustomerAsync(int customerId);
    

}