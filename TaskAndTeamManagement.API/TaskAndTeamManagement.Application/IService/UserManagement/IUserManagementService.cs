using TaskAndTeamManagement.Application.Dtos.Common;
using TaskAndTeamManagement.Application.Dtos.UserManagement;
using TaskAndTeamManagement.Application.Helpers;

namespace TaskAndTeamManagement.Application.IService.UserManagement
{
    public interface IUserManagementService
    {
        Task<ApiResponse<UserDto>> AddUserAsync(UserDto userDto);
        Task<ApiResponse<UserDto>> UpdateUserAsync(UserDto userDto);
        Task<ApiResponse<bool>> DeleteUserAsync(int userId);
        Task<ApiResponse<UserDto>> GetUserByIdAsync(int userId);
        Task<ApiResponse<(IEnumerable<UserDto> Users, int TotalCount)>> GetUsersAsync(PaginationRequestDto paginationRequestDto);
    }
}
