using TaskAndTeamManagement.Domain.Entities;

namespace TaskAndTeamManagement.Domain.IRepository.TaskManagement
{
    public interface ITaskManagementRepository
    {
        Task<UserTask> CreateNewTaskAsync(UserTask userTask);
    }
}
