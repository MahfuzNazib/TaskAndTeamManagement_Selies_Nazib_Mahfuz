using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskAndTeamManagement.Application.Dtos.TeamManagement;
using TaskAndTeamManagement.Application.Features.TeamManagement.Commands;
using TaskAndTeamManagement.Application.Features.TeamManagement.Queries;

namespace TaskAndTeamManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamManagementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeamManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTeam([FromBody] CreateTeamDto createTeamDto)
        {
            if (createTeamDto == null)
                return BadRequest("Team data is null");

            var command = new CreateTeamCommand
            {
                Name = createTeamDto.Name,
                Description = createTeamDto.Description
            };

            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllTeams()
        {
            var query = new GetAllTeamsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
