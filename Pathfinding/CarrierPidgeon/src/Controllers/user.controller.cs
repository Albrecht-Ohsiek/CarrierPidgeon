using CarrierPidgeon.Models;
using CarrierPidgeon.Repositories;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace CarrierPidgeon.Config
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            // Implement logic to create a user in the database
            _userRepository.CreateUser(user);
            return Ok(user);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(ObjectId userId)
        {
            // Implement logic to retrieve a user by ID from the database
            _userRepository.GetUserById(userId);
            return Ok();
            // Return the user data in the response (e.g., 200 OK)
        }

        [HttpPut("update/{userId}")]
        public async Task<IActionResult> UpdateUser(ObjectId userId, [FromBody] User user)
        {
            // Implement logic to update a user in the database
            _userRepository.UpdateUser(userId, user);
            return Ok();
            // Return appropriate HTTP response (e.g., 200 OK)
        }
    }
}