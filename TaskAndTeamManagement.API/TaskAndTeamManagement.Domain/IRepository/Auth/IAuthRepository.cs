
using TaskAndTeamManagement.Domain.Entities;

namespace TaskAndTeamManagement.Domain.IRepository.Auth
{
    public interface IAuthRepository
    {
        public Task<User> UserRegistrationAsync(User user);
        Task<User> UserLoginAsync(string email);
    }
}
