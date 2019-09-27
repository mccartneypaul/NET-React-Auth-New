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
    public class ContractsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContractsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contracts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contract>>> GetContracts()
        {
            return await _context.Contracts.ToListAsync();
        }

        // GET: api/Contracts/guid
        [HttpGet("{id}")]
        public async Task<ActionResult<Contract>> GetContract(Guid id)
        {
            var contract = await _context.Contracts.FindAsync(id);

            if (contract == null)
            {
                return NotFound();
            }

            return contract;
        }

        // POST: api/Contracts
        [HttpPost]
        public async Task<ActionResult<Contract>> PostContract(Contract item)
        {
            item.ContractID = Guid.NewGuid();
            _context.Contracts.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContract), new { id = item.ContractID }, item);
        }

        // PUT: api/Contracts/guid
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContract(Guid id, Contract item)
        {
            var contract = await _context.Contracts.FindAsync(id);
            if (contract == null)
            {
                return BadRequest();
            }
            contract.ContractDescription = item.ContractDescription;
            contract.ContractStartDate = item.ContractStartDate;
            contract.ContractEndDate = item.ContractEndDate;
            contract.ContractCustomerID = item.ContractCustomerID;

            _context.Entry(contract).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Contracts/guid
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContract(Guid id)
        {
            var contract = await _context.Contracts.FindAsync(id);

            if (contract == null)
            {
                return NotFound();
            }

            _context.Contracts.Remove(contract);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
