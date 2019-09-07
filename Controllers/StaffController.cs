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
    public class StaffController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Staff
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaff()
        {
            return await _context.Staff.ToListAsync();
        }

        // GET: api/Staff/guid
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaff(Guid id)
        {
            var staff = await _context.Staff.FindAsync(id);

            if (staff == null)
            {
                return NotFound();
            }

            return staff;
        }

        // POST: api/Staff
        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff(Staff item)
        {
            item.StaffID = Guid.NewGuid();
            _context.Staff.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStaff), new { id = item.StaffID }, item);
        }

        // PUT: api/Staff/guid
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(Guid id, Staff item)
        {
            var staff = await _context.Staff.FindAsync(id);
            if (staff == null)
            {
                return BadRequest();
            }
            staff.StaffFirstName = item.StaffFirstName;
            staff.StaffLastName = item.StaffLastName;
            staff.StaffRole = item.StaffRole;
            staff.StaffEmail = item.StaffEmail;

            _context.Entry(staff).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Staff/guid
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(Guid id)
        {
            var staff = await _context.Staff.FindAsync(id);

            if (staff == null)
            {
                return NotFound();
            }

            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
