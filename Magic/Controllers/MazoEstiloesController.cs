using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Magic.Context;
using Magic.Model.MagicAnalis.Mazo;

namespace MagicAnalisis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MazoEstiloesController : ControllerBase
    {
        private readonly MagicContext _context;

        public MazoEstiloesController(MagicContext context)
        {
            _context = context;
        }

        // GET: api/MazoEstiloes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MazoEstilo>>> GetMazoEstilo()
        {
          if (_context.MazoEstilo == null)
          {
              return NotFound();
          }
            return await _context.MazoEstilo.ToListAsync();
        }

        // GET: api/MazoEstiloes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MazoEstilo>> GetMazoEstilo(int id)
        {
          if (_context.MazoEstilo == null)
          {
              return NotFound();
          }
            var mazoEstilo = await _context.MazoEstilo.FindAsync(id);

            if (mazoEstilo == null)
            {
                return NotFound();
            }

            return mazoEstilo;
        }

        // PUT: api/MazoEstiloes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMazoEstilo(int id, MazoEstilo mazoEstilo)
        {
            if (id != mazoEstilo.Id)
            {
                return BadRequest();
            }

            _context.Entry(mazoEstilo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MazoEstiloExists(id))
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

        // POST: api/MazoEstiloes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MazoEstilo>> PostMazoEstilo(MazoEstilo mazoEstilo)
        {
          if (_context.MazoEstilo == null)
          {
              return Problem("Entity set 'MagicContext.MazoEstilo'  is null.");
          }
            _context.MazoEstilo.Add(mazoEstilo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMazoEstilo", new { id = mazoEstilo.Id }, mazoEstilo);
        }

        // DELETE: api/MazoEstiloes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMazoEstilo(int id)
        {
            if (_context.MazoEstilo == null)
            {
                return NotFound();
            }
            var mazoEstilo = await _context.MazoEstilo.FindAsync(id);
            if (mazoEstilo == null)
            {
                return NotFound();
            }

            _context.MazoEstilo.Remove(mazoEstilo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MazoEstiloExists(int id)
        {
            return (_context.MazoEstilo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
