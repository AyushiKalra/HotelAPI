using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelApplicaton.Model
{
    [Table("BookHotel")]
    public class BookHotel
    {
        [Key]
        [Required]
        public int BookingID { get; set; }
        public int HotelID { get; set; }
        public Decimal? BookingAmount { get; set; }

        [ForeignKey("HotelID")]
        public Hotel Hotel { get; set; }
    }
}
