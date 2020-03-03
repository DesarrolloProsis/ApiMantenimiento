using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiMantenimiento1.Models;

namespace ApiMantenimiento1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DtcdatasController : ControllerBase
    {
        private readonly ProsisDTCContext _context;

        public DtcdatasController(ProsisDTCContext context)
        {
            _context = context;
        }

        // GET: api/Dtcdatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dtcdata>>> GetDtcdata()
        {
            return await _context.Dtcdata.ToListAsync();
        }

        // GET: api/Dtcdatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dtcdata>> GetDtcdata(string id)
        {
            var dtcdata = await _context.Dtcdata.FindAsync(id);

            if (dtcdata == null)
            {
                return NotFound();
            }

            return dtcdata;
        }

        // PUT: api/Dtcdatas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDtcdata(string id, Dtcdata dtcdata)
        {
            if (id != dtcdata.ReferenceNumber)
            {
                return BadRequest();
            }

            _context.Entry(dtcdata).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DtcdataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Dtcdatas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Dtcdata>> PostDtcdata(Dtcdata dtcdata)
        {
            _context.Dtcdata.Add(dtcdata);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DtcdataExists(dtcdata.ReferenceNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDtcdata", new { id = dtcdata.ReferenceNumber }, dtcdata);
        }

        // DELETE: api/Dtcdatas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dtcdata>> DeleteDtcdata(string id)
        {
            var dtcdata = await _context.Dtcdata.FindAsync(id);
            if (dtcdata == null)
            {
                return NotFound();
            }

            _context.Dtcdata.Remove(dtcdata);
            await _context.SaveChangesAsync();

            return dtcdata;
        }

        private bool DtcdataExists(string id)
        {
            return _context.Dtcdata.Any(e => e.ReferenceNumber == id);
        }
    }
}
