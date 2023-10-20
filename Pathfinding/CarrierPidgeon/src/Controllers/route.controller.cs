using CarrierPidgeon.Handlers;
using CarrierPidgeon.Models;
using Route = CarrierPidgeon.Models.Route;
using CarrierPidgeon.Repositories;
using CarrierPidgeon.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Microsoft.AspNetCore.Cors;

namespace CarrierPidgeon.Controllers
{
    [ApiController]
    [Route("api/routes")]
    [EnableCors("MyCorsPolicy")]
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
            if (DatabaseServices.TryParseObjectId(id, out ObjectId objectId))
            {
                Route route = await _routeService.GetRouteByIdAsync(objectId);
                if (route == null)
                {
                    return NotFound();
                }
                return Ok(route);
            }
            else
            {
                return BadRequest(new ErrorResponse("Invalid ObjectId format"));
            }
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
            if (DatabaseServices.TryParseObjectId(id, out ObjectId objectId))
            {
                Route _route = await _routeService.GetRouteByIdAsync(objectId);
                if (route == null)
                {
                    return NotFound(new ErrorResponse("Route not found"));
                }
                await _routeService.UpdateRouteAsync(objectId, route);
                return Ok(_route);
            }
            else
            {
                return BadRequest(new ErrorResponse("Invalid ObjectId format"));
            }
        }
    }
}
