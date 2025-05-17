
using TaskAndTeamManagement.Domain.Enums;

namespace TaskAndTeamManagement.Application.Dtos.Auth.Registration
{
    public class UserRegistrationDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRoles Role { get; set; } // Added this property to fix the error  
    }
}
