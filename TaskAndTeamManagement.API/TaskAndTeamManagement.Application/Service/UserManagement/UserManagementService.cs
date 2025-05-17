using TaskAndTeamManagement.Application.Dtos.UserManagement;
using TaskAndTeamManagement.Application.IService.UserManagement;
using TaskAndTeamManagement.Domain.Entities;
using TaskAndTeamManagement.Domain.IRepository.UserManagement;

namespace TaskAndTeamManagement.Application.Service.UserManagement
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IUserManagementRepository _userManagementRepository;

        public UserManagementService(IUserManagementRepository userManagementRepository)
        {
            _userManagementRepository = userManagementRepository;
        }

        public async Task<UserDto> AddUserAsync(UserDto userDto)
        {
            var user = new User
            {
                FullName = userDto.FullName,
                Email = userDto.Email,
                Role = userDto.Role
            };
            var addedUser = await _userManagementRepository.AddUserAsync(user);
            
            return new UserDto
            {
                FullName = addedUser.FullName,
                Email = addedUser.Email,
                Role = addedUser.Role
            };
        }

        public async Task<UserDto> UpdateUserAsync(UserDto userDto)
        {
            var user = new User
            {
                Id = userDto.Id,
                FullName = userDto.FullName,
                Email = userDto.Email,
                Role = userDto.Role
            };
            var updatedUser = await _userManagementRepository.UpdateUserAsync(user);

            return new UserDto
            {
                Id = updatedUser.Id,
                FullName = updatedUser.FullName,
                Email = updatedUser.Email,
                Role = updatedUser.Role
            };
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            return await _userManagementRepository.DeleteUserAsync(userId);
        }

        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            var user = await _userManagementRepository.GetUserByIdAsync(userId);
            if (user == null) return null;
            return new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role
            };
        }
    }
}
