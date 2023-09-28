using Microsoft.AspNetCore.Mvc;
using CarrierPidgeon.Services;
using CarrierPidgeon.Models;
using CarrierPidgeon.Handlers;

namespace CarrierPidgeon.Controllers
{
    [ApiController]
    [Route("/dashboard")] // Define the base route for this controller
    public class Dashboard_Controller : ControllerBase
    {
        private readonly Grid_Services gridServices;
        private readonly DashboardHandler dashboardHandler;

        public Dashboard_Controller(Grid_Services gridServices)
        {
            this.gridServices = gridServices;
            this.dashboardHandler = new DashboardHandler(gridServices);
        }

        [HttpGet]
        public IActionResult GetGridInfo()
        {
            Grid_Model gridModel = gridServices.gridModel;

            return Ok("It fucking worked");
        }

        [HttpPost("SetGrid")]
        public async Task<IActionResult> SetGridSize([FromBody] Grid_Model gridModel)
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
