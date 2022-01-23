#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestMasterDetail.Models;

namespace TestMasterDetail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tbl_PartyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public tbl_PartyController(ApplicationDbContext context)
        {
            _context = context;
        }

        //// GET: api/tbl_PartyType/getmaxtypeid
        //[HttpGet]
        //[Route("{id}")]

        [HttpGet]
        [Route("maxpartyid/{id}")]
        public async Task<string> GetMaxPartyId(int id)
        {
            var values = _context.tbl_Party.Where(p => p.PartyTypeId == id).Max(p => (int?)p.PartyNameId) ?? 0;
            return values.ToString();
        }

        // GET: api/tbl_Party
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tbl_Party>>> Gettbl_Party()
        {
            return await _context.tbl_Party.ToListAsync();
        }

        // GET: api/tbl_Party/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tbl_Party>> Gettbl_Party(int id)
        {
            var tbl_Party = await _context.tbl_Party.FindAsync(id);

            if (tbl_Party == null)
            {
                return NotFound();
            }

            return tbl_Party;
        }

        // PUT: api/tbl_Party/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttbl_Party(int id, tbl_Party tbl_Party)
        {
            if (id != tbl_Party.PartyNameId)
            {
                return BadRequest();
            }

            _context.Entry(tbl_Party).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_PartyExists(id))
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

        // POST: api/tbl_Party
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tbl_Party>> Posttbl_Party(tbl_Party tbl_Party)
        {
            _context.tbl_Party.Add(tbl_Party);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettbl_Party", new { id = tbl_Party.PartyNameId }, tbl_Party);
        }

        // DELETE: api/tbl_Party/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetbl_Party(int id)
        {
            var tbl_Party = await _context.tbl_Party.FindAsync(id);
            if (tbl_Party == null)
            {
                return NotFound();
            }

            _context.tbl_Party.Remove(tbl_Party);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tbl_PartyExists(int id)
        {
            return _context.tbl_Party.Any(e => e.PartyNameId == id);
        }
    }
}
