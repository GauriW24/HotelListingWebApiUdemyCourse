using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListingWebAPI.Data;
using HotelListingWebAPI.Repository;
using AutoMapper;
using HotelListingWebAPI.Models.Hotel;

namespace HotelListingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public HotelsController(IHotelRepository hotelRepository, IMapper mapper)
        {
            this._hotelRepository = hotelRepository;
            this._mapper = mapper;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDtlModel>>> Gethotel()
        {
            var hotels =  await _hotelRepository.GetAllAsync();
            return Ok(_mapper.Map<List<HotelDtlModel>>(hotels));

        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDtlModel>> GetHotel(int id)
        {
            var hotel = await _hotelRepository.GetAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<HotelDtlModel>(hotel));
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        //this is data transfer model eg. and here we transfer data from HotelDtlModel to Data.Hotel.
        public async Task<IActionResult> PutHotel(int id, HotelDtlModel hotelDtlModel)
        {
            if (id != hotelDtlModel.hotelId)
            {
                return BadRequest();
            }

            var hotel = await _hotelRepository.GetAsync(id);
            if(hotel==null)
            {
                return BadRequest();
            }
            _mapper.Map(hotelDtlModel, hotel);
            try
            {
                await _hotelRepository.UpdateAsync(hotel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await HotelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Hotel>> PostHotel(CreateHotelDto createHotelDto)
        //{
        //    var hotel = _mapper.Map<Hotel>(createHotelDto);
        //    await _hotelRepository.AddAsync(hotel); 

        //    return CreatedAtAction("GetHotel", new { id = hotel.hotelId }, hotel);
        //}
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(CreateHotelDto createHotelDto)
        {
            var hotel = _mapper.Map<Hotel>(createHotelDto);
            await _hotelRepository.AddAsync(hotel);

            return CreatedAtAction("GetHotel", new { id = hotel.hotelId }, hotel);
        }


        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _hotelRepository.GetAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            await _hotelRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> HotelExists(int id)
        {
            return await _hotelRepository.Exists(id);
        }
    }
}
