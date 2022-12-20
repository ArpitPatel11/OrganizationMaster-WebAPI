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
    public class CountryController : ControllerBase
    {
        private readonly FirstDBContext _context;

        public CountryController(FirstDBContext context)
        {
            _context = context;
        }

        // GET: api/Country
        [HttpGet]
        public async Task<ActionResult<Tblcountry>> GetTblcountries()
        {
         
            var country=  await _context.Tblcountries.FromSqlRaw("USP_Country_Get").ToListAsync();
            return Ok(country); 
        }

        // GET: api/Country/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Tblcountry>>> GetTblcountry(int id)
        {
            var result = await _context.Tblcountries.FromSqlRaw($"USP_Country_ById {id}").ToListAsync();
            return Ok(result);
        }

        // PUT: api/Country/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblcountry(int id, Tblcountry tblcountry)
        {
            if (id != tblcountry.CountryId)
            {
                return BadRequest();
            }

            _context.Entry(tblcountry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblcountryExists(id))
                {
                    return Ok(tblcountry);
                }
                else
                {
                    throw;
                }
            }

            return Ok(tblcountry);


        }

        // POST: api/Country
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tblcountry>> PostTblcountry(Tblcountry tblcountry)
        {
          if (_context.Tblcountries == null)
          {
              return Problem("Entity set 'FirstDBContext.Tblcountries'  is null.");
          }
          
            _context.Tblcountries.Add(tblcountry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblcountry", new { id = tblcountry.CountryId }, tblcountry);
        }

        //[HttpPost]

        //public async Task<IActionResult> USP_Country_InsertAsync()
        //{
            
        //}


        // DELETE: api/Country/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblcountry(int id)
        {
            if (_context.Tblcountries == null)
            {
                return NotFound();
            }
            var tblcountry = await _context.Tblcountries.FindAsync(id);
            if (tblcountry == null)
            {
                return NotFound();
            }

            _context.Tblcountries.Remove(tblcountry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("Employee")]
        public async Task<ActionResult<Tblcountry>> PostEmployee(Employee tblemployee)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set 'FirstDBContext.Tblcountries'  is null.");
            }

            _context.Employees.Add(tblemployee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblcountry", new { id = tblemployee.EmployeeId }, tblemployee);
        }

        [HttpGet("Employee")]
        public async Task<ActionResult<Tblcountry>> GetEmployee()
        {

            var emp = await _context.Employees.FromSqlRaw("USP_Employee_Get").ToListAsync();
            return Ok(emp);
        }

        private bool TblcountryExists(int id)
        {
            return (_context.Tblcountries?.Any(e => e.CountryId == id)).GetValueOrDefault();
        }
    }
}
