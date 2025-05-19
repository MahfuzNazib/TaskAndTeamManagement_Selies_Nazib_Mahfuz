namespace TaskAndTeamManagement.Application.Dtos.TeamManagement
{
    public class CreateTeamDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
