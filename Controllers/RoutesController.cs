using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdventureLoggerBackend.Data;
using AdventureLoggerBackend.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using NuGet.Packaging;

namespace AdventureLoggerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly AdventureLoggerBackendContext _context;

        public RoutesController(AdventureLoggerBackendContext context)
        {
            _context = context;
        }

        // GET: api/Routes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Route>>> GetRoute()
        {
            return await _context.Route.ToListAsync();
        }

        // GET: api/Routes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Route>> GetRoute(int id)
        {
            var Route = await _context.Route.FindAsync(id);

            if (Route == null)
            {
                return NotFound();
            }

            return Route;
        }

        // PUT: api/Routes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoute(int id, Models.Route Route)
        {
            if (id != Route.route_id)
            {
                return BadRequest();
            }

            _context.Entry(Route).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RouteExists(id))
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

        // POST: api/Routes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("{id}")]
        [HttpPost]
        public async Task<ActionResult<Models.Route>> PostRoute(int id, JObject data)
        {
            Models.Route? route = await _context.Route.FindAsync(id);
            Console.WriteLine(id);
            if (route == null)
                return NoContent();

            var routeData = JArray.Parse(route.data == null ? "[]" : route.data);
            var newRouteData = (JArray) data["data"];
            Console.WriteLine(newRouteData);

            foreach (var point in newRouteData) {
                routeData.Add(point);
            }

            route.data = routeData.ToString();
            Console.WriteLine(route.data);
            await _context.SaveChangesAsync();

            return Content("Data added");
        }

        // POST: api/Routes
        // Create a route from a name
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<Models.Route>> CreateRoute(Models.Route route)
        {
            // validate route
            if (!_context.User.Any(e => e.user_id == route.user_id))
                return NotFound("No user with that id");

            var madeRoute = _context.Route.Add(route);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoute", new { id = route.route_id }, route);
        }

        // DELETE: api/Routes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoute(int id)
        {
            var Route = await _context.Route.FindAsync(id);
            if (Route == null)
            {
                return NotFound();
            }

            _context.Route.Remove(Route);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RouteExists(int id)
        {
            return _context.Route.Any(e => e.route_id == id);
        }
    }
}
