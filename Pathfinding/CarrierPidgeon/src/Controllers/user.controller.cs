using CarrierPidgeon.Keys;
using CarrierPidgeon.Models;
using CarrierPidgeon.Repositories;
using CarrierPidgeon.Services.Responses;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace CarrierPidgeon.Config
{
    [Route("/api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly Keygen _keygen;

        public UserController(IUserRepository userRepository, Keygen keygen)
        {
            _userRepository = userRepository;
            _keygen = keygen;
        }

        [HttpPost("register")]
        public async Task<IActionResult> registerUser([FromBody] RegisterRequest  user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            if (user.password != user.confirmPassword)
            {
                return BadRequest(new ErrorResponse("Passwords do not match"));
            }

            User existingEmail = await _userRepository.GetUserByEmail(user.email);
            if(existingEmail != null)
            {
                return Conflict(new ErrorResponse("Email already exists"));
            }

            User existingName = await _userRepository.GetUserByName(user.name);
            if(existingName != null)
            {
                return Conflict(new ErrorResponse("Username already exists"));
            }

            User _User = new User(){
                name = user.name,
                email = user.email,
                password = user.password //hashed in frontend
            };

            await _userRepository.RegisterUser(_User);
            return Ok();
        }

        [HttpGet("login")]
        public async Task<IActionResult> loginUSer([FromBody] LoginRequest user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            User _user = await _userRepository.GetUserByName(user.name);
            if (user == null)
            {
                return Unauthorized();
            }

            if (user.password != _user.password)
            {
                return Unauthorized();
            }

            string jwt = _keygen.GenerateToken(_user);

            return Ok(new AuthenticatedResponse(){
                Token = jwt
            });
        }

        

        // [HttpPost("create")]
        // public async Task<IActionResult> CreateUser([FromBody] User user)
        // {
        //     // Implement logic to create a user in the database
        //     _userRepository.CreateUser(user);
        //     return Ok(user);
        // }

        // [HttpGet("userId/{userId}")]
        // public async Task<IActionResult> GetUserById([FromRoute] string userId)
        // {
        //     if (DatabaseServices.TryParseObjectId(userId, out ObjectId objectId))
        //     {
        //         User user = await _userRepository.GetUserById(objectId);
        //         if (user == null) 
        //         {
        //             return NotFound(); // Return a 404 Not Found response if the user is not found.
        //         }
        //         return Ok(user);
        //     }
        //     else
        //     {
        //         return BadRequest("Invalid ObjectId format");
        //     }
        // }

        // [HttpGet("name/{name}")]
        // public async Task<IActionResult> GetUserIdByName([FromRoute] string name)
        // {
        //     User user = await _userRepository.GetUserIdByName(name);
        //     if (user == null)
        //     {
        //         return NotFound(); // Return a 404 Not Found response if the user is not found.
        //     }

        //     string formattedId = $"\"{user._id.ToString()}\"";

        //     return Ok(formattedId);
        // }

        // [HttpPut("update/{userId}")]
        // public async Task<IActionResult> UpdateUser([FromRoute] string userId, [FromBody] User user)
        // {
        //     if (DatabaseServices.TryParseObjectId(userId, out ObjectId objectId))
        //     {
        //         var existingUser = await _userRepository.GetUserById(objectId);

        //         if (existingUser == null)
        //         {
        //             return NotFound("User not found");
        //         }

        //         user._id = existingUser._id;

        //         _userRepository.UpdateUser(objectId, user);
        //         return Ok(user);
        //     }
        //     else
        //     {
        //         return BadRequest("Invalid ObjectId format");
        //     }
        // }
        
    }
}
