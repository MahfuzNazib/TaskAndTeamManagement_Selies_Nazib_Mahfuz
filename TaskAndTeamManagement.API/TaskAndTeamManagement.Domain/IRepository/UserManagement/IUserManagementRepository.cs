using TaskAndTeamManagement.Domain.Entities;

namespace TaskAndTeamManagement.Domain.IRepository.UserManagement
{
    public interface IUserManagementRepository
    {
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int userId);
        Task<User> GetUserByIdAsync(int userId);
        //Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
