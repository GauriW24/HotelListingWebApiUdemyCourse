using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListingWebAPI.Data;
using AutoMapper;
using HotelListingWebAPI.Repository;
using HotelListingWebAPI.Models.Country;

namespace HotelListingWebAPI.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        //private readonly HotelListingDbContext _context;
        //mapper
        private readonly IMapper _mapper;
        //repository
        private readonly ICountryRepository _countryRepository;

        public CountriesController(IMapper mapper, ICountryRepository countryRepository)
        {
            //_context = context;
            _mapper = mapper;
            _countryRepository = countryRepository;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountryModel>>> Getcountry()
        {
            //var countries = _context.country.ToListAsync();
            var countries = _countryRepository.GetAllAsync();
            var records = _mapper.Map<List<GetCountryModel>>(countries);
            return Ok(records);


        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDtlModel>> GetCountry(int id)
        {
            //var country = await _context.country.FindAsync(id);

            //var country = await _context.country.Include(s=>s.Hotels).Where(s=> s.Id == id).FirstOrDefaultAsync();

            var country = await _countryRepository.GetDetails(id);

            if (country == null)
            {
                return NotFound();
            }

            var countryDtlModel = _mapper.Map<CountryDtlModel>(country);

            return countryDtlModel;
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryModel updateCountryModel)
        {
            if (id != updateCountryModel.Id)
            {
                return BadRequest();
            }

            //_context.Entry(country).State = EntityState.Modified;

            //var country = await _context.country.FindAsync(id);
            var country = await _countryRepository.GetAsync(id);

            if(country==null)
            {
                return NotFound();
            }
            //Map objects
            _mapper.Map(updateCountryModel, country);

            try
            {
                await _countryRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
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

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Country>> PostCountry(Country country)
        //{
        //    _context.country.Add(country);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        //}

        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CountryModel countryModel)
        {
            //var country = new Country //this is table name
            //{
            //    Name = countryModel.Name,
            //    shortName = countryModel.shortName
            //};

            //use of mapper 
            var country = _mapper.Map<Country>(countryModel);

            //_context.country.Add(country);
            //await _context.SaveChangesAsync();
            _countryRepository.AddAsync(country!);
        

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            //var country = await _context.country.FindAsync(id);
            var country = await _countryRepository.GetAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            //_context.country.Remove(country);
            //await _context.SaveChangesAsync();
            await _countryRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            //return _context.country.Any(e => e.Id == id);
            return await _countryRepository.Exists(id);
        }
    }
}
