using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskAndTeamManagement.Application.Dtos.TaskManagement;
using TaskAndTeamManagement.Application.IService.TaskManagement;

namespace TaskAndTeamManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagementController : ControllerBase
    {
        private readonly ITaskManagementService _taskManagementService;

        public TaskManagementController(ITaskManagementService taskManagementService)
        {
            _taskManagementService = taskManagementService;
        }

        [HttpPost("assign-task")]
        public async Task<IActionResult> AssignNewTask([FromBody] UserTaskDto userTaskDto)
        {
            if (userTaskDto == null)
                return BadRequest("Task info null");

            var assignedTask = await _taskManagementService.CreateNewTaskAsync(userTaskDto);
            return Ok(assignedTask);
        }
    }
}
