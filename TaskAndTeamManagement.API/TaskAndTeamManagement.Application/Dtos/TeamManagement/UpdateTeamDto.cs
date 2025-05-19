namespace TaskAndTeamManagement.Application.Dtos.TeamManagement
{
    public class UpdateTeamDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
