using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiMantenimiento1.Models;
using Microsoft.AspNetCore.Cors;

namespace ApiMantenimiento1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAPIRequest")]
    public class DtcusersController : ControllerBase
    {
        private readonly ProsisDTCContext _context;

        public DtcusersController(ProsisDTCContext context)
        {
            _context = context;
        }

        // GET: api/Dtcusers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dtcusers>>> GetDtcusers()
        {
            return await _context.Dtcusers.ToListAsync();
        }

        //// GET: api/Dtcusers/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Dtcusers>> GetDtcusers(int id)
        //{
        //    var dtcusers = await _context.Dtcusers.FindAsync(id);

        //    if (dtcusers == null)
        //    {
        //        return NotFound();
        //    }

        //    return dtcusers;
        //}
        [HttpGet("{Mail}/{Pass}")]
        public async Task<ActionResult<List<object>>> GetDtcusers(string Mail, string Pass)
        {

            //var usuario = await _context.Dtcusers.ToListAsync();
            var usuario = await (from b in _context.Dtcusers
                                 join c in _context.UserSquare on b.UserId equals c.UserId
                                 join d in _context.SquaresCatalog on c.SquareCatalogId equals d.SquareCatalogId
                                 join e in _context.AgreementInfo on d.SquareCatalogId equals e.SquareCatalogId
                                 where b.Mail == Mail && b.Password == Pass
                                 select new
                                 {
                                     userName = b.UserName,
                                     nombreTec = b.LastName1 + ' ' + b.LastName2,
                                     plazaHeader = d.SquareCatalogId.ToString() + ' ' + d.SquareName,
                                     convenio = e.Agrement,
                                     mangerName = e.ManagerName,
                                     posicion = e.Position,
                                     mail = e.Mail

                                 }).ToListAsync();

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // PUT: api/Dtcusers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDtcusers(int id, Dtcusers dtcusers)
        {
            if (id != dtcusers.UserId)
            {
                return BadRequest();
            }

            _context.Entry(dtcusers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DtcusersExists(id))
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

        // POST: api/Dtcusers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Dtcusers>> PostDtcusers(Dtcusers dtcusers)
        {
            _context.Dtcusers.Add(dtcusers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDtcusers", new { id = dtcusers.UserId }, dtcusers);
        }

        // DELETE: api/Dtcusers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dtcusers>> DeleteDtcusers(int id)
        {
            var dtcusers = await _context.Dtcusers.FindAsync(id);
            if (dtcusers == null)
            {
                return NotFound();
            }

            _context.Dtcusers.Remove(dtcusers);
            await _context.SaveChangesAsync();

            return dtcusers;
        }

        private bool DtcusersExists(int id)
        {
            return _context.Dtcusers.Any(e => e.UserId == id);
        }
    }
}
