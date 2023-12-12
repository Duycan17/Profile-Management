using System.Collections.Generic;
using System.Threading.Tasks;
using JWTAuth.Models;
using JWTAuth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> GetUserById(int userId)
        {
            var user = await _userService.GetUserById(userId);

            if (user == null)
                return NotFound(); // Return 404 if user not found

            return Ok(user);
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User newUser)
        {
            var createdUser = await _userService.CreateUserAsync(newUser);
            return CreatedAtAction(nameof(GetUserById), new { userId = createdUser.UserId }, createdUser);
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<User>> UpdateUser(int userId, [FromBody] User updatedUser)
        {
            var user = await _userService.UpdateUserAsync(userId, updatedUser);

            if (user == null)
                return NotFound(); // Return 404 if user not found

            return Ok(user);
        }
        [HttpDelete("{userId}")]
        public async Task<ActionResult<bool>> DeleteUser(int userId)
        {
            var result = await _userService.DeleteUserAsync(userId);

            if (!result)
                return NotFound(); // Return 404 if user not found

            return Ok(result);
        }
    }
}
