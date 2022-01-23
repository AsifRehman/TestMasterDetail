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
    public class tbl_PartyCategController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public tbl_PartyCategController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/tbl_PartyCateg
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tbl_PartyCateg>>> Gettbl_PartyCateg()
        {
            return await _context.tbl_PartyCateg.ToListAsync();
        }

        // GET: api/tbl_PartyCateg/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tbl_PartyCateg>> Gettbl_PartyCateg(int id)
        {
            var tbl_PartyCateg = await _context.tbl_PartyCateg.FindAsync(id);

            if (tbl_PartyCateg == null)
            {
                return NotFound();
            }

            return tbl_PartyCateg;
        }

        // PUT: api/tbl_PartyCateg/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttbl_PartyCateg(int id, tbl_PartyCateg tbl_PartyCateg)
        {
            if (id != tbl_PartyCateg.PartyCategId)
            {
                return BadRequest();
            }

            _context.Entry(tbl_PartyCateg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_PartyCategExists(id))
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

        // POST: api/tbl_PartyCateg
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tbl_PartyCateg>> Posttbl_PartyCateg(tbl_PartyCateg tbl_PartyCateg)
        {
            _context.tbl_PartyCateg.Add(tbl_PartyCateg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettbl_PartyCateg", new { id = tbl_PartyCateg.PartyCategId }, tbl_PartyCateg);
        }

        // DELETE: api/tbl_PartyCateg/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetbl_PartyCateg(int id)
        {
            var tbl_PartyCateg = await _context.tbl_PartyCateg.FindAsync(id);
            if (tbl_PartyCateg == null)
            {
                return NotFound();
            }

            _context.tbl_PartyCateg.Remove(tbl_PartyCateg);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tbl_PartyCategExists(int id)
        {
            return _context.tbl_PartyCateg.Any(e => e.PartyCategId == id);
        }
    }
}
