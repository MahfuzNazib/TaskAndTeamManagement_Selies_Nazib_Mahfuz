namespace TaskAndTeamManagement.Domain.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<UserTask> UserTasks { get; set; } = new List<UserTask>();
    }
}
