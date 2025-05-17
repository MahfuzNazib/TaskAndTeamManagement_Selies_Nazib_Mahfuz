using TaskAndTeamManagement.Application.Dtos.Common;
using TaskAndTeamManagement.Application.Dtos.UserManagement;
using TaskAndTeamManagement.Application.Helpers;
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


        public async Task<ApiResponse<UserDto>> AddUserAsync(UserDto userDto)
        {
            var user = new User
            {
                FullName = userDto.FullName,
                Email = userDto.Email,
                Role = userDto.Role
            };
            var addedUser = await _userManagementRepository.AddUserAsync(user);

            var resultDto = new UserDto
            {
                Id = addedUser.Id,
                FullName = addedUser.FullName,
                Email = addedUser.Email,
                Role = addedUser.Role
            };

            return new ApiResponse<UserDto>
            {
                Status = true,
                Message = "User added successfully.",
                Values = resultDto
            };
        }

        public async Task<ApiResponse<UserDto>> UpdateUserAsync(UserDto userDto)
        {
            var user = new User
            {
                Id = userDto.Id,
                FullName = userDto.FullName,
                Email = userDto.Email,
                Role = userDto.Role
            };
            var updatedUser = await _userManagementRepository.UpdateUserAsync(user);

            var resultDto = new UserDto
            {
                Id = updatedUser.Id,
                FullName = updatedUser.FullName,
                Email = updatedUser.Email,
                Role = updatedUser.Role
            };

            return new ApiResponse<UserDto>
            {
                Status = true,
                Message = "User updated successfully.",
                Values = resultDto
            };
        }

        public async Task<ApiResponse<bool>> DeleteUserAsync(int userId)
        {
            var result = await _userManagementRepository.DeleteUserAsync(userId);
            return new ApiResponse<bool>
            {
                Status = result,
                Message = result ? "User deleted successfully." : "User not found.",
                Values = result
            };
        }

        public async Task<ApiResponse<UserDto>> GetUserByIdAsync(int userId)
        {
            var user = await _userManagementRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                return new ApiResponse<UserDto>
                {
                    Status = false,
                    Message = "User not found.",
                    Values = null
                };
            }

            var resultDto = new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role
            };

            return new ApiResponse<UserDto>
            {
                Status = true,
                Message = "User retrieved successfully.",
                Values = resultDto
            };
        }

        public async Task<ApiResponse<(IEnumerable<UserDto> Users, int TotalCount)>> GetUsersAsync(PaginationRequestDto paginationRequestDto)
        {
            var result = await _userManagementRepository.GetUsersAsync(
                paginationRequestDto.pageNumber,
                paginationRequestDto.pageSize,
                paginationRequestDto.search,
                paginationRequestDto.sortBy,
                paginationRequestDto.sortAsc
            );

            var userDtos = result.Users.Select(user => new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role
            });

            return new ApiResponse<(IEnumerable<UserDto> Users, int TotalCount)>
            {
                Status = true,
                Message = "Users retrieved successfully.",
                Values = (userDtos, result.TotalCount),
                PaginationSummary = new PaginationSummary
                {
                    Page = paginationRequestDto.pageNumber,
                    PerPage = paginationRequestDto.pageSize,
                    TotalCount = result.TotalCount
                }
            };
        }

    }
}
