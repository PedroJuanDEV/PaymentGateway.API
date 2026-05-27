using Microsoft.AspNetCore.Mvc;
using PaymentGateway.API.Data;
using PaymentGateway.API.DTOs;
using PaymentGateway.API.Models;

namespace PaymentGateway.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly PaymentDbContext _context;

        public CustomersController(PaymentDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerRequestDto request)
        {
            // Transforma o DTO em uma Entidade do Banco
            var customer = new Customer
            {
                Name = request.Name,
                Email = request.Email,
                Document = request.Document
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            // Retorna status 201 (Created) e os dados gerados (incluindo o Guid)
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }
    }
}