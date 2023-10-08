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
    public class MazoColorsController : ControllerBase
    {
        private readonly MagicContext _context;

        public MazoColorsController(MagicContext context)
        {
            _context = context;
        }

        // GET: api/MazoColors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MazoColor>>> GetMazoColor()
        {
          if (_context.MazoColor == null)
          {
              return NotFound();
          }
            return await _context.MazoColor.ToListAsync();
        }

        // GET: api/MazoColors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MazoColor>> GetMazoColor(int id)
        {
          if (_context.MazoColor == null)
          {
              return NotFound();
          }
            var mazoColor = await _context.MazoColor.FindAsync(id);

            if (mazoColor == null)
            {
                return NotFound();
            }

            return mazoColor;
        }

        // PUT: api/MazoColors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMazoColor(int id, MazoColor mazoColor)
        {
            if (id != mazoColor.Id)
            {
                return BadRequest();
            }

            _context.Entry(mazoColor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MazoColorExists(id))
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

        // POST: api/MazoColors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MazoColor>> PostMazoColor(MazoColor mazoColor)
        {
          if (_context.MazoColor == null)
          {
              return Problem("Entity set 'MagicContext.MazoColor'  is null.");
          }
            _context.MazoColor.Add(mazoColor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMazoColor", new { id = mazoColor.Id }, mazoColor);
        }

        // DELETE: api/MazoColors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMazoColor(int id)
        {
            if (_context.MazoColor == null)
            {
                return NotFound();
            }
            var mazoColor = await _context.MazoColor.FindAsync(id);
            if (mazoColor == null)
            {
                return NotFound();
            }

            _context.MazoColor.Remove(mazoColor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MazoColorExists(int id)
        {
            return (_context.MazoColor?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
