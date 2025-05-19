using MediatR;
using TaskAndTeamManagement.Application.Helpers;

namespace TaskAndTeamManagement.Application.Features.TeamManagement.Commands
{
    public class CreateTeamCommand : IRequest<ApiResponse<int>>
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}
