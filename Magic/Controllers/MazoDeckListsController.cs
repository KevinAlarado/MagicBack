using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Magic.Context;
using Magic.Model.MagicAnalis.Mazo;
using Magic.Model.MagicAnalis.Mazo.Estructuras;
using Newtonsoft.Json;
using Magic.Model.MagicAnalis;

namespace MagicAnalisis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MazoDeckListsController : ControllerBase
    {
        private readonly MagicContext _context;
        public MazoDeckListsController(MagicContext context)
        {
            _context = context;
        }

        // GET: api/MazoDeckLists
        [HttpGet]
        public async Task<ResponseApi> GetMazoDeckList()
        {
            var response = new ResponseApi();

          if (_context.MazoDeckList == null)
          {
                response.msg = "Error, no se encontraron datos";
                response.status = false;
                return response;

           }
            var content = await _context.MazoDeckList.ToListAsync();

            response.msg = "Ok"; 
            response.status = true; 
            response.value = content;
            
            return response;
        }

        // GET: api/MazoDeckLists/5
        [HttpGet("{id}")]
        public async Task<ResponseApi> GetMazoDeckList(int id)
        {
            var response = new ResponseApi();

            if (_context.MazoDeckList == null)
            {
                response.msg = "Error, no se encontraron datos";
                response.status = false;
                return response;
            }
            var mazoDeckList = await _context.MazoDeckList.FindAsync(id);

            if (mazoDeckList == null)
            {
                response.msg = "Error, no se encontro registro";
                response.status = false;
                return response;
            }
            response.msg = "Ok";
            response.status = true;
            response.value = mazoDeckList;
            return response;
        }

        // Buscar cartas especificas de un mazo
        [HttpGet("carta/{mazo}/{carta}")]
        public async Task<ResponseApi> buscarCarta(int mazo, string carta)
        {
            var response = new ResponseApi();

            if (_context.MazoDeckList == null)
            {
                response.msg = "Error, no se encontraron datos";
                response.status = false;
                return response;
            }
            var mazoDeckList = await _context.MazoDeckList
                    .Where(x => x.Mazo == mazo)
                    .Select(x => new MazoDeckList
                    {
                        Id = x.Id,
                        Mazo = x.Mazo,
                        Copias = x.Copias,
                        NombreCarta = x.NombreCarta,
                        NomEsp = x.NomEsp
                    })
            .ToListAsync();

            if (mazoDeckList == null || mazoDeckList.Count == 0)
            {
                response.msg = "Error, no se encontraron datos";
                response.status = false;
                return response; 
            }
            response.msg = "Ok";
            response.status = true;
            response.value = mazoDeckList;
            return response;
        }

        //Buscar Cartas de un mazo
        [HttpGet("mazo/{mazo}")]
        public async Task<ResponseApi> buscarMazo(int mazo)
        {
            var response = new ResponseApi();

            if (_context.MazoDeckList == null)
            {
                response.msg = "Error, no se encontraron datos";
                response.status = false;
                return response;
            }
            var mazoDeckList = await _context.MazoDeckList
                    .Where(x => x.Mazo == mazo)
                    .Select(x => new MazoDeckList
                    {
                        Id = x.Id,
                        Mazo = x.Mazo,
                        Copias = x.Copias,
                        NombreCarta = x.NombreCarta,
                        NomEsp = x.NomEsp
                    })
            .ToListAsync();

            if (mazoDeckList == null || mazoDeckList.Count == 0)
            {
                response.msg = "Error, no se encontraron datos";
                response.status = false;
                return response;
            }

            response.msg = "Ok";
            response.status = true;
            response.value = mazoDeckList;
            return response;
        }

        // PUT: api/MazoDeckLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ResponseApi> PutMazoDeckList(int id, MazoDeckList mazoDeckList)
        {
            var response = new ResponseApi();

            if (id != mazoDeckList.Id)
            {
                response.msg = "Error, no se encontraron datos";
                response.status = false;
                return response;
            }

            _context.Entry(mazoDeckList).State = EntityState.Modified;

            try
            {

                await _context.SaveChangesAsync();
                response.msg = "Ok";
                response.status = true;
                return response;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MazoDeckListExists(id))
                {
                    response.msg = "Error, no se encontraron datos";
                    response.status = false;
                    return response;
                }
                else
                {
                    throw;
                }
            }

            response.msg = "Error, no se encontraron datos";
            response.status = false;
            return response;
        }

        // POST: api/MazoDeckLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ResponseApi> PostMazoDeckList(MazoDeckList mazoDeckList)
        {
            var response = new ResponseApi();

            if (_context.MazoDeckList == null)
            {
                response.msg = "Error, no se encontraron datos";
                response.status = false;
                return response;
            }
            _context.MazoDeckList.Add(mazoDeckList);
            await _context.SaveChangesAsync();

            response.msg = "Ok";
            response.status = true;
            return response; 
        }

        // DELETE: api/MazoDeckLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMazoDeckList(int id)
        {
            if (_context.MazoDeckList == null)
            {
                return NotFound();
            }
            var mazoDeckList = await _context.MazoDeckList.FindAsync(id);
            if (mazoDeckList == null)
            {
                return NotFound();
            }

            _context.MazoDeckList.Remove(mazoDeckList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MazoDeckListExists(int id)
        {
            return (_context.MazoDeckList?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private bool MazoExists(int id)
        {
            return (_context.Mazo?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpPost("guardarLista")]
        public async Task<ResponseApi> guardarLista([FromBody] MazoInsert lista)
        {
            var response = new ResponseApi();
            var listaJson = crearListaCartasJson(lista.listaCartas,lista.Mazo.Id);

            if (!MazoExists(lista.Mazo.Id))
            {
                await PostMazo(lista.Mazo);

            }

            foreach (var carta in listaJson)
            {
                await PostMazoDeckList(carta);
            }

            response.msg = "Ok";
            response.status = true;
            return response;
        }

        private List<MazoDeckList> crearListaCartasJson(string listaCartasTexto, int Mazo)
        {
            var lineas = listaCartasTexto.Split('\n');
            var cartasJson = new List<object>();
            var listaCartas = new List<MazoDeckList>();
            foreach (var linea in lineas)
            {
                var partes = linea.Split(' ');
                if (partes.Length >= 2 && Int16.TryParse(partes[0], out Int16 copias))
                {
                    var nombreCarta = string.Join(" ", partes, 1, partes.Length - 1);
                    var carta = new MazoDeckList { Mazo = Mazo, Copias = copias, NombreCarta = nombreCarta, NomEsp = "No registrada" };
                    listaCartas.Add(carta);
                }
            }

            return listaCartas;
        }

        [HttpGet("CrearMazo/{tipo}")]
        public async Task<ResponseApi> armarMazo(int tipo)
        {
            var response = new ResponseApi();
            if (_context.MazoDeckList == null)
            {
                response.msg = "Error, no se encontraron datos";
                response.status = false;
                return response;
            }

            var mazoDeckList = await (
                from ml in _context.MazoDeckList
                join m in _context.Mazo on ml.Mazo equals m.Id
                where m.Tipo == tipo
                group ml by ml.NombreCarta into g
                select new MazoCrear
                {
                    NombreCarta = g.Key,
                    TotalCopias = g.Sum(x => x.Copias) / ( g.Select(x => x.Mazo).Distinct().Count())
                }
            ).ToListAsync();

            if (mazoDeckList == null || mazoDeckList.Count == 0)
            {
                response.msg = "No hay registros";
                response.status = false;
                return response;
            }

            response.msg = "Ok";
            response.status = true;
            response.value = mazoDeckList;

            return response; 
        }


        private async Task<ActionResult<Mazo>> PostMazo(Mazo mazo)
        {
            if (_context.Mazo == null)
            {
                return Problem("Entity set 'MagicContext.Mazo'  is null.");
            }
            _context.Mazo.Add(mazo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMazo", new { id = mazo.Id }, mazo);
        }
    }
}
