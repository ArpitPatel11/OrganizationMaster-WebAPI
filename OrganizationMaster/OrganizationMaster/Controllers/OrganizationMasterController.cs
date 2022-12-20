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
    public class OrganizationMasterController : ControllerBase
    {
        private readonly FirstDBContext _context;

        public OrganizationMasterController(FirstDBContext context)
        {
            _context = context;
        }

        // GET: api/OrganizationMaster
        //[HttpGet("{page}")]
        //public async Task<ActionResult<List<Tblorganizationmaster>>> GetTblorganizationmasters(int page)
        //{
        //  if (_context.Tblorganizationmasters == null)

        //      return NotFound();


        //    var pageResults = 3f;
        //    var pageCount = Math.Ceiling(_context.Tblorganizationmasters.Count() / pageResults);


        //    return await _context.Tblorganizationmasters
        //        .Skip((page - 1) * (int)pageResults)
        //        .Take((int)pageResults)
        //        .ToListAsync();

        //    //var response = new PaginationResponse
        //    //{
        //    //    Tblorganizationmaster = organizationMasters;
        //    //    CurrentPage = page;
        //    //    Pages = (int)pageCount;
        //    //};
        //    //return Ok(response);

        //    //return Ok(Tblorganizationmaster);

        //}

        // GET: api/OrganizationMaster/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tblorganizationmaster>>> GetTblOrganizations()
        {
            if (_context.Tblorganizationmasters == null)
            {
                return NotFound();
            }
            return await _context.Tblorganizationmasters.ToListAsync();
        }

        [HttpGet("ById")]

        public async Task<IEnumerable<USP_Organization_ByIdResult>> Organization_ByIdResultsAsync(int? Oraganization_Id)
        {
            return await _context.GetProcedures().USP_Organization_ByIdAsync(Oraganization_Id);
        }

        // PUT: api/OrganizationMaster/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblorganizationmaster(int id, Tblorganizationmaster tblorganizationmaster)
        {
            if (id != tblorganizationmaster.OraganizationId)
            {
                return BadRequest();
            }

            _context.Entry(tblorganizationmaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblorganizationmasterExists(id))
                {
                    return Ok(tblorganizationmaster);
                }
                else
                {
                    throw;
                }
            }

            return Ok(tblorganizationmaster);
        }

        // POST: api/OrganizationMaster
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tblorganizationmaster>> PostTblorganizationmaster(Tblorganizationmaster tblorganizationmaster)
        {
          if (_context.Tblorganizationmasters == null)
          {
              return Problem("Entity set 'FirstDBContext.Tblorganizationmasters'  is null.");
          }
            _context.Tblorganizationmasters.Add(tblorganizationmaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTblOrganizations), new { id = tblorganizationmaster.OraganizationId }, tblorganizationmaster);
        }

        // DELETE: api/OrganizationMaster/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblorganizationmaster(int id)
        {
            if (_context.Tblorganizationmasters == null)
            {
                return NotFound();
            }
            var tblorganizationmaster = await _context.Tblorganizationmasters.FindAsync(id);
            if (tblorganizationmaster == null)
            {
                return NotFound();
            }

            _context.Tblorganizationmasters.Remove(tblorganizationmaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

      
        private bool TblorganizationmasterExists(int id)
        {
            return (_context.Tblorganizationmasters?.Any(e => e.OraganizationId == id)).GetValueOrDefault();
        }
    }
}
