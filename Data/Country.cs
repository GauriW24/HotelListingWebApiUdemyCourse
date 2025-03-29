namespace HotelListingWebAPI.Data
{
    public class Country
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? shortName { get; set; }

        public virtual IList<Hotel>? Hotels { get; set; }
    }
}
