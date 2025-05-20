using Microsoft.EntityFrameworkCore;
using TaskAndTeamManagement.Domain.Entities;
using TaskAndTeamManagement.Domain.IRepository.TaskManagement;
using TaskAndTeamManagement.Infrastructure.DatabaseContext;

namespace TaskAndTeamManagement.Infrastructure.Repository.TaskManagement
{
    public class TaskManagementRepository : ITaskManagementRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskManagementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserTask> CreateNewTaskAsync(UserTask userTask)
        {
            await _context.UserTasks.AddAsync(userTask);
            await _context.SaveChangesAsync();

            return userTask;
        }
    }
}
