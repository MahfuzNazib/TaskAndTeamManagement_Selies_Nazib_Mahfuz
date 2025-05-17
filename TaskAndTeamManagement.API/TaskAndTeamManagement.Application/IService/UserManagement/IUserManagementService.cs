using TaskAndTeamManagement.Application.Dtos.UserManagement;

namespace TaskAndTeamManagement.Application.IService.UserManagement
{
    public interface IUserManagementService
    {
        Task<UserDto> AddUserAsync(UserDto userDto);
        Task<UserDto> UpdateUserAsync(UserDto userDto);
        Task<bool> DeleteUserAsync(int userId);
        Task<UserDto> GetUserByIdAsync(int userId);
        //Task<IEnumerable<UserDto>> GetAllUsersAsync();
    }
}
