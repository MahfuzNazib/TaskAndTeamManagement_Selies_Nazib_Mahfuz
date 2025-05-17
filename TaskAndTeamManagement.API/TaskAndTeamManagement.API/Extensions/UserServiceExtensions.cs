using TaskAndTeamManagement.Application.IService.UserManagement;
using TaskAndTeamManagement.Application.Service.UserManagement;
using TaskAndTeamManagement.Domain.IRepository.UserManagement;
using TaskAndTeamManagement.Infrastructure.Repository.UserManagement;

namespace TaskAndTeamManagement.API.Extensions
{
    public static class UserServiceExtensions
    {
        public static IServiceCollection AddUserManagementServices(this IServiceCollection services)
        {
            services.AddScoped<IUserManagementService, UserManagementService>();
            services.AddScoped<IUserManagementRepository, UserManagementRepository>();
            
            return services;
        }
    }
}
