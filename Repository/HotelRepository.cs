using HotelListingWebAPI.Data;
using HotelListingWebAPI.Repository;

namespace HotelListingWebAPI.Repository
{
    public class HotelRepository: GenericRepository<Hotel> , IHotelRepository
    {
        public HotelRepository(HotelListingDbContext context) : base(context) { }

    }
}
