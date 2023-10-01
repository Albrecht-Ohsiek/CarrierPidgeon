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
            GridModel gridModel = gridServices.gridModel;

            return Ok("It fucking worked");
        }

        [HttpPost("SetGrid")]
        public async Task<IActionResult> SetGridSize([FromBody] GridModel gridModel)
        {
            return await dashboardHandler.SetGridSize(gridModel);
        }

        [HttpPost("SetNodeType")]
        public async Task<IActionResult> SetNodeType()
        {
            return await dashboardHandler.SetNodeType();
        }

    }
}
