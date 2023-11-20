using CarrierPidgeon.Models;
using CarrierPidgeon.Repositories;
using CarrierPidgeon.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace CarrierPidgeon.Controllers
{
    [ApiController]
    [Route("/api/drones")]
    [EnableCors("MyCorsPolicy")]
    public class DroneController : ControllerBase
    {
        private readonly DroneServices droneServices;
        private List<Node> nodes;
        private readonly DroneRepository _droneRepository;

        public DroneController(DroneServices droneServices, List<Node> nodes, DroneRepository droneRepository)
        {
            this.nodes = nodes;
            this.droneServices = droneServices;
            _droneRepository = droneRepository;
        }
        
        //[Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateDrone([FromBody] Drone drone)
        {
            _droneRepository.addDrone(drone);
            return Ok(drone);
        }

        //[Authorize]
        [HttpGet("droneId/{droneId}")]
        public async Task<IActionResult> GetDroneByDroneId(string droneId)
        {
            if (DatabaseServices.TryParseObjectId(droneId, out ObjectId objectId))
            {
                Drone drone = await _droneRepository.GetDroneByDroneId(objectId);
                if (drone == null)
                {
                    return NotFound(); // Return a 404 Not Found response if the drone is not found.
                }
                return Ok(drone);
            }
            else
            {
                return BadRequest("Invalid ObjectId format");
            }
        }

        //[Authorize]
        [HttpGet("userId/{userId}")]
        public async Task<IActionResult> GetDroneByUserId(string userId)
        {
                Drone drone = await _droneRepository.GetDroneByUserId(userId);
                if (drone == null)
                {
                    return NotFound();
                }
                return Ok(drone);
        }

        //[Authorize]
        [HttpPut("update/{droneId}")]
        public async Task<IActionResult> UpdateDrone([FromRoute] string droneId, [FromBody] Drone drone)
        {
            if (DatabaseServices.TryParseObjectId(droneId, out ObjectId objectId))
            {
                var existingDrone = await _droneRepository.GetDroneByDroneId(objectId);

                if (existingDrone == null)
                {
                    return NotFound("Drone not found");
                }

                drone._id = existingDrone._id;

                _droneRepository.UpdateDrone(objectId, drone);
                return Ok(drone);
            }
            else
            {
                return BadRequest("Invalid ObjectId format");
            }
        }
    }
}