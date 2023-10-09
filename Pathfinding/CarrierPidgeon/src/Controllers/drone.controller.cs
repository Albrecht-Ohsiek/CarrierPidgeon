using CarrierPidgeon.Handlers;
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
        private List<Node> nodes;

        public DroneController(DroneServices droneServices, List<Node> nodes)
        {
            this.nodes = nodes;
            this.droneServices = droneServices;
        }

        // TODO
        [HttpGet("GetPath")]
        public IActionResult GetDroneInfo(ObjectId droneId)
        {
            return DroneHandler.GetPath(nodes);
        }

        [HttpPost("{Node}")]
        public IActionResult setObstacle(Node node)
        {
            Drone grid = droneServices.drone;

            return Ok("Added Node");
        }
    }
}