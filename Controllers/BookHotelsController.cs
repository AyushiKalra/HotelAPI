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
    public class BookHotelsController : ControllerBase
    {
        private readonly DataContext _context;

        public BookHotelsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/BookHotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookHotel>>> GetBookHotel()
        {
            return await _context.BookHotel.Include(x => x.Hotel).ToListAsync();
        }

        // GET: api/BookHotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookHotel>> GetBookHotel(int id)
        {
            var bookHotel = await _context.BookHotel.FindAsync(id);

            if (bookHotel == null)
            {
                return NotFound();
            }

            return bookHotel;
        }

        // PUT: api/BookHotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookHotel(int id, BookHotel bookHotel)
        {
            if (id != bookHotel.BookingID)
            {
                return BadRequest();
            }

            _context.Entry(bookHotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookHotelExists(id))
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

        // POST: api/BookHotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookHotel>> PostBookHotel(BookHotel bookHotel)
        {
            _context.BookHotel.Add(bookHotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookHotel", new { id = bookHotel.BookingID }, bookHotel);
        }

        // DELETE: api/BookHotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookHotel(int id)
        {
            var bookHotel = await _context.BookHotel.FindAsync(id);
            if (bookHotel == null)
            {
                return NotFound();
            }

            _context.BookHotel.Remove(bookHotel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookHotelExists(int id)
        {
            return _context.BookHotel.Any(e => e.BookingID == id);
        }
    }
}
