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
    }
}
