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
    public class tbl_LedgerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public tbl_LedgerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/tbl_Ledger
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tbl_Ledger>>> Gettbl_Ledger()
        {
            return await _context.tbl_Ledger.ToListAsync();
        }

        // GET: api/tbl_Ledger/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tbl_Ledger>> Gettbl_Ledger(int id)
        {
            var tbl_Ledger = await _context.tbl_Ledger.FindAsync(id);

            if (tbl_Ledger == null)
            {
                return NotFound();
            }

            return tbl_Ledger;
        }

        // PUT: api/tbl_Ledger/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttbl_Ledger(int id, tbl_Ledger tbl_Ledger)
        {
            if (id != tbl_Ledger.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbl_Ledger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_LedgerExists(id))
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

        // POST: api/tbl_Ledger
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tbl_Ledger>> Posttbl_Ledger(tbl_Ledger tbl_Ledger)
        {
            _context.tbl_Ledger.Add(tbl_Ledger);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettbl_Ledger", new { id = tbl_Ledger.Id }, tbl_Ledger);
        }

        // DELETE: api/tbl_Ledger/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetbl_Ledger(int id)
        {
            var tbl_Ledger = await _context.tbl_Ledger.FindAsync(id);
            if (tbl_Ledger == null)
            {
                return NotFound();
            }

            _context.tbl_Ledger.Remove(tbl_Ledger);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tbl_LedgerExists(int id)
        {
            return _context.tbl_Ledger.Any(e => e.Id == id);
        }
    }
}
