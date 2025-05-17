
using Microsoft.EntityFrameworkCore;
using TaskAndTeamManagement.Domain.Entities;
using TaskAndTeamManagement.Domain.IRepository.UserManagement;
using TaskAndTeamManagement.Infrastructure.DatabaseContext;

namespace TaskAndTeamManagement.Infrastructure.Repository.UserManagement
{
    public class UserManagementRepository : IUserManagementRepository
    {
        private readonly ApplicationDbContext _context;
        public UserManagementRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        //public async Task<IEnumerable<User>> GetAllUsersAsync()
        //{
        //    return await _context.Users.ToListAsync();
        //}


        public async Task<(IEnumerable<User> Users, int TotalCount)> GetUsersAsync(int pageNumber, int pageSize, string search, string sortBy, bool sortAsc)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(u =>
                    u.FullName.Contains(search) ||
                    u.Email.Contains(search));
            }

            int totalCount = await query.CountAsync();

            if (!string.IsNullOrEmpty(sortBy))
            {
                query = sortAsc
                    ? query.OrderBy(u => EF.Property<object>(u, sortBy))
                    : query.OrderByDescending(u => EF.Property<object>(u, sortBy));
            }

            var users = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (users, totalCount);
        }
    }
}
