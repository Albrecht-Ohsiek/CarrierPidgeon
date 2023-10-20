using System.Security.Claims;
using CarrierPidgeon.Keys;
using CarrierPidgeon.Models;
using CarrierPidgeon.Repositories;
using CarrierPidgeon.Services.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Route = CarrierPidgeon.Models.Route;

namespace CarrierPidgeon.Controllers
{
    [ApiController]
    [Route("api/routes")]
    [EnableCors("MyCorsPolicy")]
    public class RouteController : ControllerBase
    {
        private readonly IRouteRepository _routeRepository;
        private List<Node> nodes;

        public RouteController(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoutes()
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            List<Route> routes = await _routeRepository.GetAllRoutes();
            return Ok(routes);
        }

        [HttpGet("routeId/{routeId}")]
        public async Task<IActionResult> GetRouteById(string routeId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            if (DatabaseServices.TryParseObjectId(routeId, out ObjectId objectId))
            {
                Route route = await _routeRepository.GetRouteById(objectId);
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

        [HttpPost("create")]
        public async Task<IActionResult> CreateRoute([FromBody] AddRouteRequest route)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            Route _route = new Route()
            {
                status = route.status,
                path = route.path
            };

            await _routeRepository.CreateRoute(_route);
            return Ok(_route);
        }

        [HttpPut("update/{routeId}")]
        public async Task<IActionResult> UpdateRoute([FromRoute] string routeId, [FromBody] UpdateRouteRequest route)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            if (DatabaseServices.TryParseObjectId(routeId, out ObjectId objectId))
            {
                Route exsistingRoute = await _routeRepository.GetRouteById(objectId);
                if (exsistingRoute == null)
                {
                    return NotFound(new ErrorResponse("Route does not exist"));
                }

                Route _route = new Route()
                {
                    _id = exsistingRoute._id,
                    status = route.status,
                    path = exsistingRoute.path
                };

                await _routeRepository.UpdateRoute(objectId, _route);
                return Ok(_route);
            }
            else
            {
                return BadRequest(new ErrorResponse("Invalid ObjectId format"));
            }
        }
    }
}
