using MediatR;
using TaskAndTeamManagement.Application.Dtos.TeamManagement;
using TaskAndTeamManagement.Application.Helpers;

namespace TaskAndTeamManagement.Application.Features.TeamManagement.Queries
{
    public class GetAllTeamsQuery : IRequest<ApiResponse<List<TeamDto>>>
    {
    }
}
