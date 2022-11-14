using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApplicaton.Model
{
    [Table("Hotel")]
    public class Hotel
    {
        [Key]
        [Required]
        public int HotelID { get; set; }
        public string? HotelName { get; set; }
        public int CityCode { get; set; }
        public List<HotelDetails> Details { get; set; }

    }
}
