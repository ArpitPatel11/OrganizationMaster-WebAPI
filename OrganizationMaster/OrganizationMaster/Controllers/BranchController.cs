using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganizationMaster.Data;
using OrganizationMaster.Models;

namespace OrganizationMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly FirstDBContext _context;

        public BranchController(FirstDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tblbranchmaster>>> GetTblbranches()
        {
            if (_context.Tblbranchmasters == null)
            {
                return NotFound();
            }
            return await _context.Tblbranchmasters.ToListAsync();
        }


        [HttpGet("ById")]

        public async Task<IEnumerable<USP_Branch_ByIdResult>> Branch_ByIdResultsAsync(int? Branch_Id)
        {
            return await _context.GetProcedures().USP_Branch_ByIdAsync(Branch_Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblBranchMaster(int id, Tblbranchmaster tblbranchmaster)
        {
            if (id != tblbranchmaster.BranchId)
            {
                return BadRequest();
            }

            _context.Entry(tblbranchmaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblorganizationmasterExists(id))
                {
                    return Ok(tblbranchmaster);
                }
                else
                {
                    throw;
                }
            }

            return Ok(tblbranchmaster);
        }

        [HttpPost]
        public async Task<ActionResult<Tblbranchmaster>> PostTblBranchnmaster(Tblbranchmaster tblbranchmaster)
        {
            if (_context.Tblbranchmasters == null)
            {
                return Problem("Entity set 'FirstDBContext.Tblbranchmasters'  is null.");
            }
            _context.Tblbranchmasters.Add(tblbranchmaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTblbranches), new { id = tblbranchmaster.BranchId }, tblbranchmaster);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblBranchmaster(int id)
        {
            if (_context.Tblbranchmasters == null)
            {
                return NotFound();
            }
            var tblbranchmaster = await _context.Tblbranchmasters.FindAsync(id);
            if (tblbranchmaster == null)
            {
                return NotFound();
            }

            _context.Tblbranchmasters.Remove(tblbranchmaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool TblorganizationmasterExists(int id)
        {
            return (_context.Tblorganizationmasters?.Any(e => e.OraganizationId == id)).GetValueOrDefault();
        }
    }
}
