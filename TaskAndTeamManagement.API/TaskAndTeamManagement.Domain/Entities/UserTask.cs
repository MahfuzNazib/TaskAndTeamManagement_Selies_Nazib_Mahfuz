namespace TaskAndTeamManagement.Domain.Entities
{
    public class UserTask
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TaskStatus Status { get; set; }

        public int AssignedToUserId { get; set; }
        public required User AssignedToUser { get; set; }

        public int CreatedByUserId { get; set; }
        public required User CreatedByUser { get; set; }

        public int TeamId { get; set; }
        public required Team Team { get; set; }

        public DateTime DueDate { get; set; }
    }
}
