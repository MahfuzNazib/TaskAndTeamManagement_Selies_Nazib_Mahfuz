using TaskAndTeamManagement.Application.Features.TeamManagement.Handler;
using TaskAndTeamManagement.Application.Interfaces.TeamManagement;
using TaskAndTeamManagement.Domain.IRepository.TeamManagement;
using TaskAndTeamManagement.Infrastructure.Repository.TeamManagement;

namespace TaskAndTeamManagement.API.Extensions
{
    public static class TeamManagementServiceExtensions
    {
        public static IServiceCollection AddTeamManagementServices(this IServiceCollection services)
        {
            services.AddScoped<ITeamManagementRepository, TeamManagementRepository>();
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<CreateTeamCommandHandler>();
            });
            return services;
        }
    }
}
