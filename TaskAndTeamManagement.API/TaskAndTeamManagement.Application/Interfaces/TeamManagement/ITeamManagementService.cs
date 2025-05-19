using TaskAndTeamManagement.Application.Dtos.TeamManagement;
using TaskAndTeamManagement.Application.Helpers;

namespace TaskAndTeamManagement.Application.Interfaces.TeamManagement
{
    public interface ITeamManagementService
    {
        Task<ApiResponse<int>> CreateTeamAsync(CreateTeamDto createTeamDto);

        Task<ApiResponse<List<TeamDto>>> GetAllTeamAsync();
    }
}
