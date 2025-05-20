using TaskAndTeamManagement.Application.IService.TaskManagement;
using TaskAndTeamManagement.Application.Service.TaskManagement;
using TaskAndTeamManagement.Domain.IRepository.TaskManagement;
using TaskAndTeamManagement.Infrastructure.Repository.TaskManagement;

namespace TaskAndTeamManagement.API.Extensions
{
    public static class TaskAssignmentServiceExtensions
    {
        public static IServiceCollection AddTaskAssignmentServices(this IServiceCollection services)
        {
            services.AddScoped<ITaskManagementService, TaskManagementService>();
            services.AddScoped<ITaskManagementRepository, TaskManagementRepository>();

            return services;
        }
    }
}
