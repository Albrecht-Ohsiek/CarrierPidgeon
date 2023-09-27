using CarrierPidgeon.Models;
using CarrierPidgeon.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace CarrierPidgeon.Controllers
{
    [ApiController]
    [Route("/drone")]
    public class Drone_Controller : ControllerBase
    {  
        private readonly Drone_Services droneServices;

        public Drone_Controller(Drone_Services droneServices)
        {
            this.droneServices = droneServices;
        }

        [HttpGet("{droneId}")]
        public IActionResult GetDroneInfo(ObjectId droneId)
        {
            Drone_Model gridModel = droneServices.droneModel;

            return Ok($"{droneId} was selected");
        }

        [HttpPost("{Node}")]
        public IActionResult setObstacle(Node node)
        {
            Drone_Model gridModel = droneServices.droneModel;

            return Ok("Added Node");
        }

    }
}