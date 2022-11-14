using HotelApplicaton.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace HotelApplicaton.DAC
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelDetails> HotelDetails { get; set; }

        public DbSet<BookHotel> BookHotel { get; set; }
    }
}
