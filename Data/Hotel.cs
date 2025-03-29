using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListingWebAPI.Data
{
    public class Hotel
    {
        public int hotelId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Rating { get; set; }
        [ForeignKey("countryId")]
        public int countryId { get; set; }

        public Country? country { get; set; }
    }
}
