using BirdAndBrew.DTOs.CustomerDTOs;
using BirdAndBrew.Services.CustomerServices;
using Microsoft.AspNetCore.Mvc;

namespace BirdAndBrew.Controllers;

[Route("api/customers")]
[ApiController]


public class CustomersController : ControllerBase
{

    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
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

    [HttpPatch]

    public async Task<ActionResult<CustomerDTO>> UpdateCustomerField(CustomerDTO customer)
    {
        var updated = await _customerService.UpdateCustomerFieldAsync(customer);
        
        if (!updated)
        {
            return NotFound();
        }
        
        return Ok(customer.Id);

    }
    

}