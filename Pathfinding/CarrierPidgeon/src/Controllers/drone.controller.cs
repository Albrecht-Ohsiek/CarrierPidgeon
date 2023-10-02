using CarrierPidgeon.Models;
using CarrierPidgeon.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace CarrierPidgeon.Controllers
{
    [ApiController]
    [Route("/drone")]
    public class DroneController : ControllerBase
    {  
        private readonly DroneServices droneServices;

        public DroneController(DroneServices droneServices)
        {
            this.droneServices = droneServices;
        }

        // TODO
        [HttpGet("{droneId}")]
        public IActionResult GetDroneInfo(ObjectId droneId)
        {
            DroneModel gridModel = droneServices.droneModel;

            return Ok($"{droneId} was selected");
        }

        [HttpPost("{Node}")]
        public IActionResult setObstacle(Node node)
        {
            DroneModel gridModel = droneServices.droneModel;

            return Ok("Added Node");
        }

    }
}