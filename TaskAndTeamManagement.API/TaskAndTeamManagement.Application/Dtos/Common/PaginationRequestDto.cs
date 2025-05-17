
namespace TaskAndTeamManagement.Application.Dtos.Common
{
    public class PaginationRequestDto
    {
        public int pageNumber { get; set; } = 1;
        public int pageSize { get; set; } = 10;
        public string search { get; set; } = string.Empty;
        public string sortBy { get; set; } = string.Empty;
        public bool sortAsc { get; set; } = true;
    }
}
