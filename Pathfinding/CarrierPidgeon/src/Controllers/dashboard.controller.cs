using Microsoft.AspNetCore.Mvc;
using CarrierPidgeon.Services;
using CarrierPidgeon.Models;
using CarrierPidgeon.Handlers;

namespace CarrierPidgeon.Controllers
{
    [ApiController]
    [Route("/dashboard")] // Define the base route for this controller
    public class DashboardController : ControllerBase
    {

        private readonly GridServices gridServices;
        private readonly DashboardHandler dashboardHandler;
        private List<Node> nodes;

        public DashboardController(GridServices gridServices, List<Node> nodes)
        {
            this.nodes = nodes;
            this.gridServices = gridServices;
            this.dashboardHandler = new DashboardHandler(gridServices, nodes);
        }

        [HttpGet]
        public IActionResult GetGridInfo()
        {
            Grid grid = gridServices.grid;
            

            return Ok("It fucking worked");
        }

        [HttpPost("SetGrid")]
        public IActionResult SetGridSize([FromBody] Grid grid)
        {
            return dashboardHandler.SetGridSize(grid);
        }

        [HttpPost("SetNode")]
        public IActionResult SetNodes([FromBody] List<Node> nodes)
        {
            return dashboardHandler.SetNodes(nodes);
        }

    }
}
