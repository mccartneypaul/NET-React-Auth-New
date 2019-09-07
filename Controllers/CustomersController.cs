using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NET_React_Auth_New.Data;
using NET_React_Auth_New.Models;

namespace NET_React_Auth_New.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customers/guid
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer item)
        {
            item.CustomerID = Guid.NewGuid();
            _context.Customers.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomer), new { id = item.CustomerID }, item);
        }

        // PUT: api/Customers/guid
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(Guid id, Customer item)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return BadRequest();
            }
            customer.CustomerFirstName = item.CustomerFirstName;
            customer.CustomerLastName = item.CustomerLastName;
            customer.CustomerCompanyName = item.CustomerCompanyName;
            customer.CustomerFirstStreetAddress = item.CustomerFirstStreetAddress;
            customer.CustomerScndStreetAddress = item.CustomerScndStreetAddress;
            customer.CustomerCity = item.CustomerCity;
            customer.CustomerState = item.CustomerState;
            customer.CustomerZipCode = item.CustomerZipCode;
            customer.CustomerCountry = item.CustomerCountry;
            customer.CustomerPhoneNumber = item.CustomerPhoneNumber;
            customer.CustomerEmail = item.CustomerEmail;

            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Customers/guid
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
