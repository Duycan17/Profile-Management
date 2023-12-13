using System.Collections.Generic;
using System.Threading.Tasks;
using JWTAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _dbContext;

        public UserService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _dbContext.Users.FindAsync(userId);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> CreateUserAsync(User newUser)
        {
            _dbContext.Users.Add(newUser);
            await SaveChangesAsync();
            return newUser;
        }

        public async Task<User> UpdateUserAsync(int userId, User updatedUser)
        {
            var existingUser = await _dbContext.Users.FindAsync(userId);

            if (existingUser == null)
                return null; // User not found

            // Update properties
            existingUser.UserName = updatedUser.UserName;
            existingUser.Email = updatedUser.Email;

            await SaveChangesAsync();
            return existingUser;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var userToDelete = await _dbContext.Users.FindAsync(userId);

            if (userToDelete == null)
                return false; // User not found

            _dbContext.Users.Remove(userToDelete);
            await SaveChangesAsync();
            return true;
        }

        public async System.Threading.Tasks.Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public Task<User> GetUserByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
