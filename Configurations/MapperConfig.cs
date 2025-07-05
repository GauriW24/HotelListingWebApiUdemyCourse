using AutoMapper;
using HotelListingWebAPI.Data;
using HotelListingWebAPI.Models.Country;
using HotelListingWebAPI.Models.Hotel;


namespace HotelListingWebAPI.Configurations
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<Country, CountryModel>().ReverseMap();
            CreateMap<Country, GetCountryModel>().ReverseMap();
            CreateMap<Country, CountryDtlModel>().ReverseMap();
            CreateMap<Country, UpdateCountryModel>().ReverseMap();

            CreateMap<Hotel, HotelDtlModel>().ReverseMap();
            CreateMap<Hotel, CreateHotelDto>().ReverseMap();
        }
    }
}
