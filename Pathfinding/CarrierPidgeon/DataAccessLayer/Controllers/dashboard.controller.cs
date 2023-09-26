using Microsoft.AspNetCore.Mvc;

namespace CarrierPidgeon.Controllers
{
    [ApiController]
    [Route("/dashboard")] // Define the base route for this controller
    public class Dashboard_Controller : ControllerBase
    {
        private readonly Grid_Services gridServices;

        public Dashboard_Controller(Grid_Services gridServices)
        {
            this.gridServices = gridServices;
        }

        [HttpGet]
        public IActionResult GetGridInfo()
        {
            Grid_Model gridModel = gridServices.grid_model;

            return Ok("It fucking worked");
        }

        // Define additional actions and routes here, e.g., [HttpGet("otherAction")]
    }
}
