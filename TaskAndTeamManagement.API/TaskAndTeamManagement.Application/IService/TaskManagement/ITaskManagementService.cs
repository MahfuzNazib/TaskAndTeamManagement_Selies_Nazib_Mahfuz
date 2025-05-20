using TaskAndTeamManagement.Application.Dtos.TaskManagement;

namespace TaskAndTeamManagement.Application.IService.TaskManagement
{
    public interface ITaskManagementService
    {
        Task<UserTaskDto> CreateNewTaskAsync(UserTaskDto userTaskDto);
    }
}
