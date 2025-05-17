using TaskAndTeamManagement.Domain.Enums;

namespace TaskAndTeamManagement.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public string Password { get; set; } = string.Empty;
        public string? Salt { get; set; } = string.Empty;
        public string? Token { get; set; } = string.Empty;
        public string? RefreshToken { get; set; } = string.Empty;
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public UserRoles Role { get; set; }

        // Navigation Property
        public ICollection<UserTask> AssignedTasks { get; set; } = new List<UserTask>();
        public ICollection<UserTask> CreatedTasks { get; set; } = new List<UserTask>();
    }
}
