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
    public class tbl_PartyTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public tbl_PartyTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        //// GET: api/tbl_PartyType/getmaxtypeid
        //[HttpGet]
        //[Route("{id}")]

        [HttpGet]
        [Route("maxtypeid/{id}")]
        public async Task<string> GetMaxTypeId(int id)
        {
            var values = _context.tbl_PartyType.Where(p => p.PartyCategId == id).Max(p =>(int?) p.PartyTypeId) ?? 0;
            return values.ToString();
        }

        // GET: api/tbl_PartyType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tbl_PartyType>>> Gettbl_PartyType()
        {
            return await _context.tbl_PartyType.ToListAsync();
        }

        // GET: api/tbl_PartyType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tbl_PartyType>> Gettbl_PartyType(int id)
        {
            var tbl_PartyType = await _context.tbl_PartyType.FindAsync(id);

            if (tbl_PartyType == null)
            {
                return NotFound();
            }

            return tbl_PartyType;
        }

        // PUT: api/tbl_PartyType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttbl_PartyType(int id, tbl_PartyType tbl_PartyType)
        {
            if (id != tbl_PartyType.PartyTypeId)
            {
                return BadRequest();
            }

            _context.Entry(tbl_PartyType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_PartyTypeExists(id))
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

        // POST: api/tbl_PartyType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tbl_PartyType>> Posttbl_PartyType(tbl_PartyType tbl_PartyType)
        {
            _context.tbl_PartyType.Add(tbl_PartyType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettbl_PartyType", new { id = tbl_PartyType.PartyTypeId }, tbl_PartyType);
        }

        // DELETE: api/tbl_PartyType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetbl_PartyType(int id)
        {
            var tbl_PartyType = await _context.tbl_PartyType.FindAsync(id);
            if (tbl_PartyType == null)
            {
                return NotFound();
            }

            _context.tbl_PartyType.Remove(tbl_PartyType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tbl_PartyTypeExists(int id)
        {
            return _context.tbl_PartyType.Any(e => e.PartyTypeId == id);
        }
    }
}
