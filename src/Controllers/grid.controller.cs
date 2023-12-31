using CarrierPidgeon.Handlers;
using CarrierPidgeon.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CarrierPidgeon.Controllers
{
    [ApiController]
    [Route("/api/grid")]
    [EnableCors("MyCorsPolicy")]
    public class GridController : ControllerBase
    {
        private readonly List<Node> nodes;

        public GridController(List<Node> nodes)
        {
            this.nodes = nodes;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetGrid(){
            return Ok(GridHandler.GetGrid(nodes));
        }

        [Authorize]
        [HttpGet("crucials")]
        public IActionResult GetGridCrucial(){
            return Ok(GridHandler.GetGridCrucial(nodes));
        }

    }
}
