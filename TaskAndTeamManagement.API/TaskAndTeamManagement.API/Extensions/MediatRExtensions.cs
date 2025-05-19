using System.Reflection;
using TaskAndTeamManagement.Application.Features.TeamManagement.Commands;

namespace TaskAndTeamManagement.API.Extensions
{
    public static class MediatRExtensions
    {
        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateTeamCommand).Assembly);
            });
            return services;
        }
    }
}
