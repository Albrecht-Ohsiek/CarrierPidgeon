using CarrierPidgeon.Models;
using CarrierPidgeon.Repositories;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace CarrierPidgeon.Config
{
    [Route("/api/users")]
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

        [HttpGet("id/{userId}")]
        public async Task<IActionResult> GetUserById(ObjectId userId)
        {
            User user = await _userRepository.GetUserById(userId);
            if (user == null)
            {
                return NotFound(); // Return a 404 Not Found response if the user is not found.
            }
            return Ok(user);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetUserIdByName([FromRoute] string name)
        {
            User user = await _userRepository.GetUserIdByName(name);
            if (user == null)
            {
                return NotFound(); // Return a 404 Not Found response if the user is not found.
            }

            string formattedId = $"\"{user._id.ToString()}\"";

            return Ok(formattedId);
        }

        [HttpPut("update/{userId}")]
        public async Task<IActionResult> UpdateUser([FromRoute] ObjectId userId, [FromBody] User user)
        {
            var existingUser = await _userRepository.GetUserById(userId);

            if (existingUser == null)
            {
                return NotFound("User not found");
            }

            user._id = existingUser._id;

            _userRepository.UpdateUser(userId, user);
            return Ok();
        }
    }
}