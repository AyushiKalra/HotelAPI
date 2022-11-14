using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelApplicaton.DAC;
using HotelApplicaton.Model;

namespace HotelApplicaton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelDetailsController : ControllerBase
    {
        private readonly DataContext _context;

        public HotelDetailsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/HotelDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDetails>>> GetHotelDetails()
        {
            return await _context.HotelDetails.Include(x => x.Hotel).ToListAsync();
        }

        // GET: api/HotelDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDetails>> GetHotelDetails(int id)
        {
            var hotelDetails = await _context.HotelDetails.FindAsync(id);

            if (hotelDetails == null)
            {
                return NotFound();
            }

            return hotelDetails;
        }

        // PUT: api/HotelDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelDetails(int id, HotelDetails hotelDetails)
        {
            if (id != hotelDetails.DetailID)
            {
                return BadRequest();
            }

            _context.Entry(hotelDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelDetailsExists(id))
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

        // POST: api/HotelDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelDetails>> PostHotelDetails(HotelDetails hotelDetails)
        {
            _context.HotelDetails.Add(hotelDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelDetails", new { id = hotelDetails.DetailID }, hotelDetails);
        }

        // DELETE: api/HotelDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelDetails(int id)
        {
            var hotelDetails = await _context.HotelDetails.FindAsync(id);
            if (hotelDetails == null)
            {
                return NotFound();
            }

            _context.HotelDetails.Remove(hotelDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelDetailsExists(int id)
        {
            return _context.HotelDetails.Any(e => e.DetailID == id);
        }
    }
}
