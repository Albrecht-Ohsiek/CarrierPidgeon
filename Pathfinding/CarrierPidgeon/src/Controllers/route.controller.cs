using CarrierPidgeon.Handlers;
using CarrierPidgeon.Models;
using CarrierPidgeon.Repositories;
using CarrierPidgeon.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace CarrierPidgeon.Controllers
{
    [ApiController]
    [Route("api/routes")]
    public class RouteController : ControllerBase
    {
        private readonly RouteService _routeService;
        private List<Node> nodes;

        public RouteController(RouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Route>>> GetRoutes()
        {
            var routes = await _routeService.GetAllRoutesAsync();
            return Ok(routes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Route>> GetRoute(string id)
        {
            var route = await _routeService.GetRouteByIdAsync(id);
            if (route == null)
            {
                return NotFound();
            }
            return Ok(route);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRoute([FromBody] Route route)
        {
            await _routeService.CreateRouteAsync(route);
            return CreatedAtAction(nameof(GetRoute), new { id = route._id }, route);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRoute(string id, [FromBody] Route route)
        {
            var existingRoute = await _routeService.GetRouteByIdAsync(id);
            if (existingRoute == null)
            {
                return NotFound();
            }
            await _routeService.UpdateRouteAsync(id, route);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRoute(string id)
        {
            var existingRoute = await _routeService.GetRouteByIdAsync(id);
            if (existingRoute == null)
            {
                return NotFound();
            }
            await _routeService.DeleteRouteAsync(id);
            return NoContent();
        }
    }
}
