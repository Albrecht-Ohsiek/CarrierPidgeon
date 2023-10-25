using System.Security.Claims;
using CarrierPidgeon.Keys;
using CarrierPidgeon.Models;
using CarrierPidgeon.Repositories;
using CarrierPidgeon.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace CarrierPidgeon.Config
{
    [Route("/api/users")]
    [ApiController]
    [EnableCors("MyCorsPolicy")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly Keygen _keygen;

        public UserController(IUserRepository userRepository, Keygen keygen)
        {
            _userRepository = userRepository;
            _keygen = keygen;
        }

        // Using CLAIMS for validation
        // string authedId  = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "_id").Value;
        // string authedName = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name).Value;
        // string authedEmail = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email).Value;

        [HttpPost("register")]
        public async Task<IActionResult> registerUser([FromBody] RegisterRequest user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            if (user.password != user.confirmPassword)
            {
                return BadRequest(new ErrorResponse("Passwords do not match"));
            }

            User existingEmail = await _userRepository.GetUserByEmail(user.email);
            if (existingEmail != null)
            {
                return Conflict(new ErrorResponse("Email already exists"));
            }

            User existingName = await _userRepository.GetUserByName(user.name);
            if (existingName != null)
            {
                return Conflict(new ErrorResponse("Username already exists"));
            }

            User _User = new User()
            {
                name = user.name,
                email = user.email,
                password = user.password //hashed in frontend
            };

            await _userRepository.RegisterUser(_User);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> loginUSer([FromBody] LoginRequest user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            User _user = await _userRepository.GetUserByName(user.name);
            if (user == null)
            {
                return Unauthorized(new ErrorResponse("Username does not exist"));
            }

            if (user.password != _user.password)
            {
                return Unauthorized(new ErrorResponse("Passwords do not match"));
            }

            string jwt = _keygen.GenerateToken(_user);

            return Ok(new AuthenticatedResponse()
            {
                Token = jwt
            });
        }

        [Authorize]
        [HttpGet("userId/{userId}")]
        public async Task<IActionResult> GetUserById([FromRoute] string userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            if (DatabaseServices.TryParseObjectId(userId, out ObjectId objectId))
            {
                User user = await _userRepository.GetUserById(objectId);
                if (user == null)
                {
                    return NotFound(new ErrorResponse("User not found"));
                }
                return Ok(user);
            }
            else
            {
                return BadRequest(new ErrorResponse("Invalid ObjectId format"));
            }
        }

        [Authorize]
        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetUserByEmail([FromRoute] string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            User user = await _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound(new ErrorResponse("User not found"));
            }

            return Ok(user);
        }

        [Authorize]
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetUserByName([FromRoute] string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            User user = await _userRepository.GetUserByName(name);
            if (user == null)
            {
                return NotFound(new ErrorResponse("User not found"));
            }

            return Ok(user);
        }

        [Authorize]
        [HttpPut("update/user/{userId}")]
        public async Task<IActionResult> UpdateUserById([FromRoute] string userId, [FromBody] UpdateUserRequest user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            string authedId = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "_id").Value;
            string authedName = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name).Value;
            string authedEmail = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email).Value;

            if (authedId != userId)
            {
                return Unauthorized(new ErrorResponse("Invalid Permisions. Who are you?"));
            }

            if (user.password != user.confirmPassword)
            {
                return BadRequest(new ErrorResponse("Passwords do not match"));
            }

            User existingName = await _userRepository.GetUserByName(user.name);
            if (existingName != null && authedName != user.name)
            {
                return Conflict(new ErrorResponse("Username already exists"));
            }

            if (DatabaseServices.TryParseObjectId(userId, out ObjectId objectId))
            {
                User existingUser = await _userRepository.GetUserById(objectId);
                if (existingUser == null)
                {
                    return NotFound(new ErrorResponse("User does not exist"));
                }

                User _user = new User()
                {
                    _id = existingUser._id,
                    name = user.name,
                    email = existingUser.email,
                    password = user.password //hashed in frontend
                };

                await _userRepository.UpdateUserById(objectId, _user);
                return Ok(user);
            }
            else
            {
                return BadRequest(new ErrorResponse("Invalid ObjectId format"));
            }
        }

    }
}
