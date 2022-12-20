using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganizationMaster.Data;
using OrganizationMaster.Models;

namespace OrganizationMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly FirstDBContext _context;

        public StateController(FirstDBContext context)
        {
            _context = context;
        }

        // GET: api/State
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tblstate>>> GetTblstates()
        {
          if (_context.Tblstates == null)
          {
              return NotFound();
          }
            return await _context.Tblstates.ToListAsync();
        }

        [HttpGet("ById")]

        public async Task<IEnumerable<USP_State_ByIdResult>> State_ByIdResultsAsync(int? State_Id)
        {
            return await _context.GetProcedures().USP_State_ByIdAsync(State_Id);
        }

        //// GET: api/State/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Tblstate>> GetTblstate(int id)
        //{
        //  if (_context.Tblstates == null)
        //  {
        //      return NotFound();
        //  }
        //    var tblstate = await _context.Tblstates.FindAsync(id);

        //    if (tblstate == null)
        //    {
        //        return NotFound();
        //    }

        //    return tblstate;
        //}

        // PUT: api/State/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblstate(int id, Tblstate tblstate)
        {
            if (id != tblstate.StateId)
            {
                return BadRequest();
            }

            _context.Entry(tblstate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblstateExists(id))
                {
                    return Ok(tblstate);
                }
                else
                {
                    throw;
                }
            }

            return Ok(tblstate);
        }

        // POST: api/State
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tblstate>> PostTblstate([FromBody]Tblstate tblstate)

        {
          if (_context.Tblstates == null)
          {
              return Problem("Entity set 'FirstDBContext.Tblstates'  is null.");
          }
            _context.Tblstates.Add(tblstate);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTblstate", new { id = tblstate.StateId }, tblstate);
            return CreatedAtAction(nameof(GetTblstates), new { id = tblstate.StateId }, tblstate);

            //return Ok("id");
        }

        // DELETE: api/State/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblstate(int id)
        {
            if (_context.Tblstates == null)
            {
                return NotFound();
            }
            var tblstate = await _context.Tblstates.FindAsync(id);
            if (tblstate == null)
            {
                return NotFound();
            }

            _context.Tblstates.Remove(tblstate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblstateExists(int id)
        {
            return (_context.Tblstates?.Any(e => e.StateId == id)).GetValueOrDefault();
        }
    }
}
