using System.ComponentModel.DataAnnotations;

namespace HotelListingWebAPI.Models.Hotel
{
    public abstract class BaseHotelDtl
    {
        [Required]
        public string? Name { get; set; }
        [Required]

        public string? Address { get; set; }
        [Required]

        public double? Rating { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int CountryId { get; set; }
    }
}
