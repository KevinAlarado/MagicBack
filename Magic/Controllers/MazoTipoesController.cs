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
    public class MazoTipoesController : ControllerBase
    {
        private readonly MagicContext _context;

        public MazoTipoesController(MagicContext context)
        {
            _context = context;
        }

        // GET: api/MazoTipoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MazoTipo>>> GetMazoTipo()
        {
          if (_context.MazoTipo == null)
          {
              return NotFound();
          }
            return await _context.MazoTipo.ToListAsync();
        }

        // GET: api/MazoTipoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MazoTipo>> GetMazoTipo(int id)
        {
          if (_context.MazoTipo == null)
          {
              return NotFound();
          }
            var mazoTipo = await _context.MazoTipo.FindAsync(id);

            if (mazoTipo == null)
            {
                return NotFound();
            }

            return mazoTipo;
        }

        // PUT: api/MazoTipoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMazoTipo(int id, MazoTipo mazoTipo)
        {
            if (id != mazoTipo.Id)
            {
                return BadRequest();
            }

            _context.Entry(mazoTipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MazoTipoExists(id))
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

        // POST: api/MazoTipoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MazoTipo>> PostMazoTipo(MazoTipo mazoTipo)
        {
          if (_context.MazoTipo == null)
          {
              return Problem("Entity set 'MagicContext.MazoTipo'  is null.");
          }
            _context.MazoTipo.Add(mazoTipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMazoTipo", new { id = mazoTipo.Id }, mazoTipo);
        }

        // DELETE: api/MazoTipoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMazoTipo(int id)
        {
            if (_context.MazoTipo == null)
            {
                return NotFound();
            }
            var mazoTipo = await _context.MazoTipo.FindAsync(id);
            if (mazoTipo == null)
            {
                return NotFound();
            }

            _context.MazoTipo.Remove(mazoTipo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MazoTipoExists(int id)
        {
            return (_context.MazoTipo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
