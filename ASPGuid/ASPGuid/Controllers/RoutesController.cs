using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPGuid.Services;

namespace ASPGuid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly CountryService _countryService;

        public RoutesController(CountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public ActionResult<List<Models.Route>> Get() =>
        _countryService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCountry")]
        public ActionResult<Models.Route> Get(string id)
        {
            var country = _countryService.Get(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        [HttpPost]
        public ActionResult<Models.Route> Create(Models.Route country)
        {
            _countryService.Create(country);

            return CreatedAtRoute("GetCountry", new { id = country.Id.ToString() }, country);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Models.Route countryIn)
        {
            var country = _countryService.Get(id);

            if (country == null)
            {
                return NotFound();
            }

            _countryService.Update(id, countryIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var country = _countryService.Get(id);

            if (country == null)
            {
                return NotFound();
            }

            _countryService.Remove(country.Id);

            return NoContent();
        }
    }
}
