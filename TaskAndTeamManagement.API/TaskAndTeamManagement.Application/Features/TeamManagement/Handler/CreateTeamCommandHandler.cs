using MediatR;
using TaskAndTeamManagement.Application.Features.TeamManagement.Commands;
using TaskAndTeamManagement.Application.Helpers;
using TaskAndTeamManagement.Domain.Entities;
using TaskAndTeamManagement.Domain.IRepository.TeamManagement;

namespace TaskAndTeamManagement.Application.Features.TeamManagement.Handler
{
    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, ApiResponse<int>>
    {
        private readonly ITeamManagementRepository _teamManagementRepository;
        public CreateTeamCommandHandler(ITeamManagementRepository teamManagementRepository)
        {
            _teamManagementRepository = teamManagementRepository;
        }
        public async Task<ApiResponse<int>> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var team = new Team
            {
                Name = request.Name,
                Description = request.Description
            };
            var result = await _teamManagementRepository.CreateTeamAsync(team);
            return new ApiResponse<int>
            {
                Status = true,
                Message = "Team created successfully",
                Values = result
            };
        }
    }
}
