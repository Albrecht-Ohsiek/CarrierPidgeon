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

        //Example sub route ../dashboard/{userName}
        [HttpGet("{userName}")]
        public IActionResult GetGridInfoUser(string userName)
        {
            Grid_Model gridModel = gridServices.gridModel;

            return Ok($"It fucking worked {userName}");
        }

        //[HttpPost("setGrid")]
        //public IActionResult SetGridSize([FromBody] Grid_Model gridModel)
        //{
        //    try{
        //        int width = gridModel.sizeX;
        //        int bredth = gridModel.sizeY;
        //
        //        Node[,] nodes = node_services.initNodes(width, bredth);
        //
        //        return Ok("Set grid size");
        //    }
        //    catch(Exception e){
        //        return BadRequest("Failed to set grid size: " + e.Message);
        //    }         
        //}

        [HttpPost("setGrid")]
        public async Task<IActionResult> SetGridSize([FromBody] Grid_Model gridModel)
        {
            return await dashboardHandler.SetGridSize(gridModel);
        }

    }
}
