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
        private readonly RouteService _routeService;

        public RoutesController(RouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet]
        public ActionResult<List<Models.Route>> Get() =>
        _routeService.Get();

        [HttpGet("{id:length(24)}", Name = "GetRoute")]
        public ActionResult<Models.Route> Get(string id)
        {
            var country = _routeService.Get(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        [HttpPost]
        public ActionResult<Models.Route> Create(Models.Route route)
        {
            _routeService.Create(route);

            return CreatedAtRoute("GetCountry", new { id = route.Id.ToString() }, route);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Models.Route routeIn)
        {
            var route = _routeService.Get(id);

            if (route == null)
            {
                return NotFound();
            }

            _routeService.Update(id, routeIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var route = _routeService.Get(id);

            if (route == null)
            {
                return NotFound();
            }

            _routeService.Remove(route.Id);

            return NoContent();
        }
    }
}
