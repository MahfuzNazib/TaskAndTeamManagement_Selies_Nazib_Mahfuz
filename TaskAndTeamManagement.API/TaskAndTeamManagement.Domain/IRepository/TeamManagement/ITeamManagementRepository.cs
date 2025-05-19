using TaskAndTeamManagement.Domain.Entities;

namespace TaskAndTeamManagement.Domain.IRepository.TeamManagement
{
    public interface ITeamManagementRepository
    {
        Task<int> CreateTeamAsync(Team team);
    }
}
