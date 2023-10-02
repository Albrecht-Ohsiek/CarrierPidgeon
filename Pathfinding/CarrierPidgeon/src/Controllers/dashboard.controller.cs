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

        public DashboardController(GridServices gridServices)
        {
            this.gridServices = gridServices;
            this.dashboardHandler = new DashboardHandler(gridServices);
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
        public IActionResult SetNodeType([FromBody] Node node)
        {
            return dashboardHandler.SetNodeType(node);
        }

    }
}
