using MediatR;
using TaskAndTeamManagement.Application.Dtos.TeamManagement;
using TaskAndTeamManagement.Application.Features.TeamManagement.Queries;
using TaskAndTeamManagement.Application.Helpers;
using TaskAndTeamManagement.Domain.IRepository.TeamManagement;

namespace TaskAndTeamManagement.Application.Features.TeamManagement.Handler
{
    public class GetAllTeamsQueryHandler : IRequestHandler<GetAllTeamsQuery, ApiResponse<List<TeamDto>>>
    {
        private readonly ITeamManagementRepository _teamManagementRepository;
        public GetAllTeamsQueryHandler(ITeamManagementRepository teamManagementRepository)
        {
            _teamManagementRepository = teamManagementRepository;
        }
        public async Task<ApiResponse<List<TeamDto>>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken)
        {
            var teams = await _teamManagementRepository.GetAllTeamAsync();
            var teamDtos = teams.Select(team => new TeamDto
            {
                Id = team.Id,
                Name = team.Name,
                Description = team.Description,
            }).ToList();

            return new ApiResponse<List<TeamDto>>
            {
                Message = "Teams retrieved successfully",
                Status = true,
                Values = teamDtos
            };
        }
    }
}
