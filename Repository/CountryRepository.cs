using HotelListingWebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListingWebAPI.Repository
{
    public class CountryRepository: GenericRepository<Country> , ICountryRepository
    {
        private readonly HotelListingDbContext _context;
        public CountryRepository(HotelListingDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<Country?> GetDetails(int id)
        {
            return await _context.country.Include(s => s.Hotels).FirstOrDefaultAsync(s => s.Id == id)!;
        }
    }
}
