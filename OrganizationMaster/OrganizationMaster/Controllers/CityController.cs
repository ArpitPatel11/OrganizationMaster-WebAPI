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
    public class CityController : ControllerBase
    {
        private readonly FirstDBContext _context;

        public CityController(FirstDBContext context)
        {
            _context = context;
        }

        // GET: api/City
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tblcity>>> GetTblcities()
        {
            if (_context.Tblcities == null)
            {
                return NotFound();
            }
            return await _context.Tblcities.ToListAsync();


        }

        // GET: api/City/5
        //[HttpGet("ById")]
        //public async Task<IEnumerable<USP_City_ByIdResult>> GetTblcity(int City_Id)
        //{
        //    return await _context.GetProcedures().USP_City_ByIdAsync(City_Id);
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Tblcity>>> GetTblcity(int id)
        {
            var result = await _context.Tblcities.FromSqlRaw($"USP_City_ById {id}").ToListAsync();
            return Ok(result);
        }

        // PUT: api/City/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblcity(int id, Tblcity tblcity)
        {
            if (id != tblcity.CityId)
            {
                return BadRequest();
            }

            _context.Entry(tblcity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblcityExists(id))
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

        // POST: api/City
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tblcity>> PostTblcity(Tblcity tblcity)
        {
            if (_context.Tblcities == null)
            {
                return Problem("Entity set 'FirstDBContext.Tblcities'  is null.");
            }
            _context.Tblcities.Add(tblcity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblcity", new { id = tblcity.CityId }, tblcity);
        }

        // DELETE: api/City/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblcity(int id)
        {
            if (_context.Tblcities == null)
            {
                return NotFound();
            }
            var tblcity = await _context.Tblcities.FindAsync(id);
            if (tblcity == null)
            {
                return NotFound();
            }

            _context.Tblcities.Remove(tblcity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblcityExists(int id)
        {
            return (_context.Tblcities?.Any(e => e.CityId == id)).GetValueOrDefault();
        }
    }
}
