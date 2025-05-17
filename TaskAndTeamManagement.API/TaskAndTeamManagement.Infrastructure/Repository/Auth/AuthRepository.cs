using Microsoft.EntityFrameworkCore;
using TaskAndTeamManagement.Domain.Entities;
using TaskAndTeamManagement.Domain.IRepository.Auth;
using TaskAndTeamManagement.Infrastructure.DatabaseContext;

namespace TaskAndTeamManagement.Infrastructure.Repository.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public AuthRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> UserRegistrationAsync(User user)
        {
            var existingUser = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == user.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("User with this email already exists.");
            }
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UserLoginAsync(string email)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid email.");
            }
            return user;
        }

        public async Task UpdateUserTokenAsync(int userId, string token)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }
            user.Token = token;
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
