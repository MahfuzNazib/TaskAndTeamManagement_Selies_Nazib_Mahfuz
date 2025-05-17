using Microsoft.EntityFrameworkCore;
using TaskAndTeamManagement.Domain.Entities;
using TaskAndTeamManagement.Domain.Enums;

namespace TaskAndTeamManagement.Infrastructure.DatabaseContext
{
    public static class SeedData
    {
        public static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FullName = "Admin User",
                    Email = "admin@demo.com",
                    Role = UserRoles.Admin
                },
                new User
                {
                    Id = 2,
                    FullName = "Manager User",
                    Email = "manager@demo.com",
                    Role = UserRoles.Manager
                },
                new User
                {
                    Id = 3,
                    FullName = "Employee User",
                    Email = "employee@demo.com",
                    Role = UserRoles.Employee
                }
            );
        }
    }
}
