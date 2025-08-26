using BirdAndBrew.DTOs.CustomerDTOs;
using BirdAndBrew.Services.CustomerServices;
using Microsoft.AspNetCore.Mvc;

namespace BirdAndBrew.Controllers;

[Route("api/customer")]
[ApiController]


public class CustomersController : ControllerBase
{

    private readonly ICustomerService _customerService;
    private readonly IConfiguration _config;

    public CustomersController(ICustomerService customerService, IConfiguration config)
    {
        _customerService = customerService;
        _config = config;
    }


    [HttpGet]
    public async Task<ActionResult<List<CustomerDTO>>> GetAllCustomers()
    {
        var customers = await _customerService.GetAllCustomersAsync();

        return Ok(customers);
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<CustomerDTO>> GetCustomerById(int id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);

        if (customer == null)
        {
            return NotFound();        }

        return Ok(customer);
    }


    [HttpPost]
    public async Task<ActionResult<CustomerDTO>> AddCustomer(CustomerDTO customer)
    {
        var customerId = await _customerService.AddCustomerAsync(customer);

        return CreatedAtAction(nameof(GetAllCustomers), new { id = customerId });
    }


    [HttpDelete]

    public async Task<ActionResult<CustomerDTO>> DeleteCustomer(int customerId)
    {
        var deleted= await _customerService.DeleteCustomerAsync(customerId);
        
        if (!deleted)
            return NotFound();  

        return NoContent(); 

    }


    [HttpPut]

    public async Task<ActionResult<CustomerDTO>> UpdateCustomer(CustomerDTO customer)
    {
        var updated = await _customerService.UpdateCustomerAsync(customer);

        if (!updated)
        {
            return NotFound();
        }
            

        return Ok(customer.Id);
    }

}