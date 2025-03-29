using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HotelListingWebAPI.Data
{
    public class HotelListingDbContext:DbContext
    {
        public HotelListingDbContext(DbContextOptions<HotelListingDbContext> options) : base(options) 
        {
                    
        }
        public DbSet<Hotel> hotel { get; set; }
        public DbSet<Country> country { get; set; }

        protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "India",
                    shortName = "IN"
                },
                new Country
                {
                    Id = 2,
                    Name = "Russia",
                    shortName = "RA"
                },
                new Country
                {
                    Id = 3,
                    Name = "America",
                    shortName = "AMA"
                }
            );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    countryId = 1,
                    hotelId = 1,
                    Name = "IndianHotel",
                    Address = "Pimple Saudgar",
                    Rating = "4.5"
                },
                 new Hotel
                 {
                     countryId = 2,
                     hotelId = 2,
                     Name = "RussiaHotel",
                     Address = "skdjflks lksdjfs",
                     Rating = "4.4"
                 },
                  new Hotel
                  {
                      countryId = 3,
                      hotelId = 3,
                      Name = "AmericalHotel",
                      Address = "sjdfl klsdjf sldkjf",
                      Rating = "4.0"
                  }
            );
        }

    }
}
