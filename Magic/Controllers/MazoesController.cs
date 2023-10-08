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
    public class MazoesController : ControllerBase
    {
        private readonly MagicContext _context;

        public MazoesController(MagicContext context)
        {
            _context = context;
        }

        // GET: api/Mazoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mazo>>> GetMazo()
        {
          if (_context.Mazo == null)
          {
              return NotFound();
          }
            return await _context.Mazo.ToListAsync();
        }

        // GET: api/Mazoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mazo>> GetMazo(int id)
        {
          if (_context.Mazo == null)
          {
              return NotFound();
          }
            var mazo = await _context.Mazo.FindAsync(id);

            if (mazo == null)
            {
                return NotFound();
            }

            return mazo;
        }

        // PUT: api/Mazoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMazo(int id, Mazo mazo)
        {
            if (id != mazo.Id)
            {
                return BadRequest();
            }

            _context.Entry(mazo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MazoExists(id))
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

        // POST: api/Mazoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mazo>> PostMazo(Mazo mazo)
        {
          if (_context.Mazo == null)
          {
              return Problem("Entity set 'MagicContext.Mazo'  is null.");
          }
            _context.Mazo.Add(mazo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMazo", new { id = mazo.Id }, mazo);
        }

        // DELETE: api/Mazoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMazo(int id)
        {
            if (_context.Mazo == null)
            {
                return NotFound();
            }
            var mazo = await _context.Mazo.FindAsync(id);
            if (mazo == null)
            {
                return NotFound();
            }

            _context.Mazo.Remove(mazo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MazoExists(int id)
        {
            return (_context.Mazo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
