using HotelListingWebAPI.Models.Hotel;

namespace HotelListingWebAPI.Models.Country
{
    public class CountryDtlModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? shortName { get; set; }

        public List<HotelDtlModel>? hotels { get; set; }
    }
}
