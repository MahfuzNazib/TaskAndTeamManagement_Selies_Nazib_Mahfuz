using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskAndTeamManagement.Application.Dtos.UserManagement;
using TaskAndTeamManagement.Application.IService.UserManagement;

namespace TaskAndTeamManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserManagementService _userManagementService;

        public UserManagementController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody] UserDto userDto)
        {
            var result = await _userManagementService.AddUserAsync(userDto);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto userDto)
        {
            var result = await _userManagementService.UpdateUserAsync(userDto);
            return Ok(result);
        }

        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var result = await _userManagementService.DeleteUserAsync(userId);
            if (result)
            {
                return Ok(new { message = "User deleted successfully." });
            }
            return NotFound(new { message = "User not found." });
        }

        [HttpGet("get/{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var result = await _userManagementService.GetUserByIdAsync(userId);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { message = "User not found." });
        }
    }
}
