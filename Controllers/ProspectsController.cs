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
    public class ProspectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProspectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Prospects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prospect>>> GetProspects()
        {
            return await _context.Prospects.ToListAsync();
        }

        // GET: api/Prospects/guid
        [HttpGet("{id}")]
        public async Task<ActionResult<Prospect>> GetProspect(Guid id)
        {
            var prospect = await _context.Prospects.FindAsync(id);

            if (prospect == null)
            {
                return NotFound();
            }

            return prospect;
        }

        // POST: api/Prospects
        [HttpPost]
        public async Task<ActionResult<Prospect>> PostProspect(Prospect item)
        {
            item.ProspectID = Guid.NewGuid();
            _context.Prospects.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProspect), new { id = item.ProspectID }, item);
        }

        // PUT: api/Prospects/guid
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProspect(Guid id, Prospect item)
        {
            var prospect = await _context.Prospects.FindAsync(id);
            if (prospect == null)
            {
                return BadRequest();
            }
            prospect.ProspectDescription = item.ProspectDescription;
            prospect.ProspectLastUpdateDate = item.ProspectLastUpdateDate;
            prospect.ProspectLastUpdateStaff = item.ProspectLastUpdateStaff;
            prospect.ProspectRcvdDate = item.ProspectRcvdDate;

            _context.Entry(prospect).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Prospects/guid
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProspect(Guid id)
        {
            var prospect = await _context.Prospects.FindAsync(id);

            if (prospect == null)
            {
                return NotFound();
            }

            _context.Prospects.Remove(prospect);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
