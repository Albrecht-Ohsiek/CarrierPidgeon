using CarrierPidgeon.Handlers;
using CarrierPidgeon.Models;
using CarrierPidgeon.Repositories;
using CarrierPidgeon.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace CarrierPidgeon.Controllers
{
    [ApiController]
    [Route("/api/drones")]
    public class DroneController : ControllerBase
    {  
        private readonly DroneServices droneServices;
        private List<Node> nodes;
        private readonly DroneRepository _droneRepository;

        public DroneController(DroneServices droneServices, List<Node> nodes)
        {
            this.nodes = nodes;
            this.droneServices = droneServices;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] Drone drone)
        {
            _droneRepository.addDrone(drone);
            return Ok(drone);
        }

        [HttpGet("droneId/{droneId}")]
        public async Task<IActionResult> GetDroneByDroneId(ObjectId droneId)
        {
            Drone drone = await _droneRepository.GetDroneByDroneId(droneId);
            if (drone == null)
            {
                return NotFound(); // Return a 404 Not Found response if the user is not found.
            }
            return Ok(drone);
        }

        [HttpGet("userId/{userId}")]
        public async Task<IActionResult> GetDroneByUserId(ObjectId userId)
        {
            Drone drone = await _droneRepository.GetDroneByUserId(userId);
            if (drone == null)
            {
                return NotFound(); // Return a 404 Not Found response if the user is not found.
            }
            return Ok(drone);
        }

        [HttpPut("update/{droneId}")]
        public async Task<IActionResult> UpdateDrone([FromRoute] ObjectId droneId, [FromBody] Drone drone)
        {
            var existingUser = await _droneRepository.GetDroneByDroneId(droneId);

            if (existingUser == null)
            {
                return NotFound("User not found");
            }

            drone._id = existingUser._id;

            _droneRepository.UpdateDrone(droneId, drone);
            return Ok();
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