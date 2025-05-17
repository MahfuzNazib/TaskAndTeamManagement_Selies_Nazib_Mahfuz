
using TaskAndTeamManagement.API.AppExceptionHandler;
using TaskAndTeamManagement.API.Extensions;

namespace TaskAndTeamManagement.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Dependency Injection Register
            builder.Services.AddDatabaseConnection(builder.Configuration);
            builder.Services.AddAuthenticationService();
            builder.Services.AddUserManagementServices();

            #endregion

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
