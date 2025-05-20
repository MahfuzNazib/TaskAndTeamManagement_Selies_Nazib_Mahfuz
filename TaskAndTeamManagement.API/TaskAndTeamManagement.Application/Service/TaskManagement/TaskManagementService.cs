using TaskAndTeamManagement.Application.Dtos.TaskManagement;
using TaskAndTeamManagement.Application.IService.TaskManagement;
using TaskAndTeamManagement.Domain.Entities;
using TaskAndTeamManagement.Domain.IRepository.TaskManagement;

namespace TaskAndTeamManagement.Application.Service.TaskManagement
{
    public class TaskManagementService : ITaskManagementService
    {
        private readonly ITaskManagementRepository _taskManagementRepository;

        public TaskManagementService(ITaskManagementRepository taskManagementRepository)
        {
            _taskManagementRepository = taskManagementRepository;
        }

        public async Task<UserTaskDto> CreateNewTaskAsync(UserTaskDto userTaskDto)
        {
            var assignedUserTask = new UserTask
            {
                Id = userTaskDto.Id,
                Title = userTaskDto.Title,
                Description = userTaskDto.Description,
                AssignedToUserId = userTaskDto.AssignedToUserId,
                AssignedToUser = new User
                {
                    Id = userTaskDto.AssignedToUserId,
                    FullName = "Nazib Mahfuz",
                    Email = "nazibmahfuz60@gmail.com"
                },
                CreatedByUserId = userTaskDto.CreatedByUserId,
                CreatedByUser = new User
                {
                    Id = userTaskDto.CreatedByUserId,
                    FullName = "Creator Name", // Replace with actual creator's name
                    Email = "creator@example.com" // Replace with actual creator's email
                },
                TeamId = userTaskDto.TeamId,
                Team = new Team
                {
                    Id = userTaskDto.TeamId,
                    Name = "Team Name" // Replace with actual team name
                },
                DueDate = userTaskDto.DueDate
            };

            // Assuming _taskManagementRepository has a method to add and save the task
            await _taskManagementRepository.CreateNewTaskAsync(assignedUserTask);

            return userTaskDto;
        }
    }
}
