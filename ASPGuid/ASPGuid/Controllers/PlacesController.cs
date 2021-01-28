using ASPGuid.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPGuid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly PlaceService _placeService;

        public PlacesController(PlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet]
        public ActionResult<List<Models.Place>> Get() =>
         _placeService.Get();

        [HttpGet("{id:length(24)}", Name = "GetPlace")]
        public ActionResult<Models.Place> Get(string id)
        {
            var place = _placeService.Get(id);

            if (place == null)
            {
                return NotFound();
            }

            return place;
        }

        [HttpPost]
        public ActionResult<Models.Place> Create(Models.Place place)
        {
            _placeService.Create(place);

            return CreatedAtRoute("GetPlace", new { id = place.Id.ToString() }, place);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Models.Place placeIn)
        {
            var place = _placeService.Get(id);

            if (place == null)
            {
                return NotFound();
            }

            _placeService.Update(id, placeIn);

            return NoContent();
        }


        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var place = _placeService.Get(id);

            if (place == null)
            {
                return NotFound();
            }

            _placeService.Remove(place.Id);

            return NoContent();
        }
    }
}
