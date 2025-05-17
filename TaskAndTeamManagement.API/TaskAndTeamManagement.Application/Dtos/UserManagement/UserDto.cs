
using TaskAndTeamManagement.Domain.Enums;

namespace TaskAndTeamManagement.Application.Dtos.UserManagement
{
    public class UserDto
    {
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required UserRoles Role { get; set; }
        public int Id { get; internal set; }
    }
}
