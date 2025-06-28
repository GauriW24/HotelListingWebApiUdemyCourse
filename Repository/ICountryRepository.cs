using HotelListingWebAPI.Data;

namespace HotelListingWebAPI.Repository
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Task<Country> GetDetails(int id);
    }
}