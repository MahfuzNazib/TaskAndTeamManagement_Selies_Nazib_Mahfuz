using Microsoft.EntityFrameworkCore;
using TaskAndTeamManagement.Domain.Entities;
using TaskAndTeamManagement.Domain.IRepository.TeamManagement;
using TaskAndTeamManagement.Infrastructure.DatabaseContext;

namespace TaskAndTeamManagement.Infrastructure.Repository.TeamManagement
{
    public class TeamManagementRepository : ITeamManagementRepository
    {
        private readonly ApplicationDbContext _context;

        public TeamManagementRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<int> CreateTeamAsync(Team team)
        {
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
            return team.Id;
        }


        public async Task<List<Team>> GetAllTeamAsync()
        {
            return await _context.Teams.ToListAsync();
        }
    }
}
