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
    public class DepartmentMasterController : ControllerBase
    {
        private readonly FirstDBContext _context;

        public DepartmentMasterController(FirstDBContext context)
        {
            _context = context;
        }

        // GET: api/De
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbldepartmentmaster>>> GetTbldepartmentmasters()
        {
          if (_context.Tbldepartmentmasters == null)
          {
              return NotFound();
          }
            return await _context.Tbldepartmentmasters.ToListAsync();
        }

        // GET: api/De/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Tbldepartmentmaster>> GetTbldepartmentmaster(int id)
        //{
        //  if (_context.Tbldepartmentmasters == null)
        //  {
        //      return NotFound();
        //  }
        //    var tbldepartmentmaster = await _context.Tbldepartmentmasters.FindAsync(id);

        //    if (tbldepartmentmaster == null)
        //    {
        //        return NotFound();
        //    }

        //    return tbldepartmentmaster;
        //}

        [HttpGet("ById")]

        public async Task<IEnumerable<USP_Department_ByIdResult>> Department_ByIdResultsAsync(int? Department_Id)
        {
            return await _context.GetProcedures().USP_Department_ByIdAsync(Department_Id);
        }

        // PUT: api/De/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbldepartmentmaster(int id, Tbldepartmentmaster tbldepartmentmaster)
        {
            if (id != tbldepartmentmaster.DepartmentId)
            {
                return BadRequest();
            }

            _context.Entry(tbldepartmentmaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbldepartmentmasterExists(id))
                {
                    return Ok(tbldepartmentmaster);
                }
                else
                {
                    throw;
                }
            }

            return Ok(tbldepartmentmaster);
        }

        // POST: api/De
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tbldepartmentmaster>> PostTbldepartmentmaster(Tbldepartmentmaster tbldepartmentmaster)
        {
          if (_context.Tbldepartmentmasters == null)
          {
              return Problem("Entity set 'FirstDBContext.Tbldepartmentmasters'  is null.");
          }
            _context.Tbldepartmentmasters.Add(tbldepartmentmaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTbldepartmentmasters), new { id = tbldepartmentmaster.DepartmentId }, tbldepartmentmaster);
        }

        // DELETE: api/De/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbldepartmentmaster(int id)
        {
            if (_context.Tbldepartmentmasters == null)
            {
                return NotFound();
            }
            var tbldepartmentmaster = await _context.Tbldepartmentmasters.FindAsync(id);
            if (tbldepartmentmaster == null)
            {
                return NotFound();
            }

            _context.Tbldepartmentmasters.Remove(tbldepartmentmaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbldepartmentmasterExists(int id)
        {
            return (_context.Tbldepartmentmasters?.Any(e => e.DepartmentId == id)).GetValueOrDefault();
        }
    }
}
