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
    public async Task<ActionResult<List<ReadCustomerDTO>>> GetAllCustomers()
    {
        var customers = await _customerService.GetAllCustomersAsync();

        return Ok(customers);
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<ReadCustomerDTO>> GetCustomerById(int id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);

        if (customer == null)
        {
            return NotFound();        }

        return Ok(customer);
    }


    [HttpPost]
    public async Task<ActionResult<ReadCustomerDTO>> AddCustomer(CreateCustomerDTO createCustomerDTO)
    {
        var customerId = await _customerService.AddCustomerAsync(createCustomerDTO);

        return CreatedAtAction(nameof(GetAllCustomers), new { id = customerId });
    }


    [HttpDelete]

    public async Task<ActionResult<ReadCustomerDTO>> DeleteCustomer(int id)
    {
        var deleted= await _customerService.DeleteCustomerAsync(id);
        
        if (!deleted)
            return NotFound();  

        return NoContent(); 

    }


    [HttpPut("{id}")]

    public async Task<ActionResult<ReadCustomerDTO>> UpdateCustomer(int id, CreateCustomerDTO customerDTO)
    {
        var updated = await _customerService.UpdateCustomerAsync(id, customerDTO);

        if (!updated)
        {
            return NotFound();
        }
        
        return Ok(customerDTO);
    }

    

}