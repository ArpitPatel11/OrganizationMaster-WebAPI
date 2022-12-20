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
    public class DesignationMasterController : ControllerBase
    {
        private readonly FirstDBContext _context;

        public DesignationMasterController(FirstDBContext context)
        {
            _context = context;
        }

        // GET: api/DesignationMaster
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbldesignationmaster>>> GetTbldesignationmasters()
        {
          if (_context.Tbldesignationmasters == null)
          {
              return NotFound();
          }
            return await _context.Tbldesignationmasters.ToListAsync();
        }

        // GET: api/DesignationMaster/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Tbldesignationmaster>> GetTbldesignationmaster(int id)
        //{
        //  if (_context.Tbldesignationmasters == null)
        //  {
        //      return NotFound();
        //  }
        //    var tbldesignationmaster = await _context.Tbldesignationmasters.FindAsync(id);

        //    if (tbldesignationmaster == null)
        //    {
        //        return NotFound();
        //    }

        //    return tbldesignationmaster;
        //}

        [HttpGet("ById")]

        public async Task<IEnumerable<USP_Designation_ByIdResult>> Designation_ByIdResultsAsync(int? Designation_Id)
        {
            return await _context.GetProcedures().USP_Designation_ByIdAsync(Designation_Id);
        }

        // PUT: api/DesignationMaster/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbldesignationmaster(int id, Tbldesignationmaster tbldesignationmaster)
        {
            if (id != tbldesignationmaster.DesignationId)
            {
                return BadRequest();
            }

            _context.Entry(tbldesignationmaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbldesignationmasterExists(id))
                {
                    return Ok(tbldesignationmaster);
                }
                else
                {
                    throw;
                }
            }

            return Ok(tbldesignationmaster);
        }

        // POST: api/DesignationMaster
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tbldesignationmaster>> PostTbldesignationmaster(Tbldesignationmaster tbldesignationmaster)
        {
          if (_context.Tbldesignationmasters == null)
          {
              return Problem("Entity set 'FirstDBContext.Tbldesignationmasters'  is null.");
          }
            _context.Tbldesignationmasters.Add(tbldesignationmaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTbldesignationmasters), new { id = tbldesignationmaster.DesignationId }, tbldesignationmaster);
        }

        // DELETE: api/DesignationMaster/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbldesignationmaster(int id)
        {
            if (_context.Tbldesignationmasters == null)
            {
                return NotFound();
            }
            var tbldesignationmaster = await _context.Tbldesignationmasters.FindAsync(id);
            if (tbldesignationmaster == null)
            {
                return NotFound();
            }

            _context.Tbldesignationmasters.Remove(tbldesignationmaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbldesignationmasterExists(int id)
        {
            return (_context.Tbldesignationmasters?.Any(e => e.DesignationId == id)).GetValueOrDefault();
        }
    }
}
