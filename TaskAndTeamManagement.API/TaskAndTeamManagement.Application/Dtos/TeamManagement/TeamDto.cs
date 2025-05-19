namespace TaskAndTeamManagement.Application.Dtos.TeamManagement
{
    public class TeamDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
