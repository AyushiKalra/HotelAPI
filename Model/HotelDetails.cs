using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApplicaton.Model
{
    [Table("HotelDetails")]
    public class HotelDetails
    {
        [Key]
        [Required]
        public int DetailID { get; set; }
        public int HotelID { get; set; }
        public int HotelPhoneNum { get; set; }
        public string HotelEmail { get; set; }

        [ForeignKey("HotelID")]
        public Hotel Hotel { get; set; }    
    }
}
