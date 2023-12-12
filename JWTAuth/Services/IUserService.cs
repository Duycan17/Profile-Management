using System.Collections.Generic;
using System.Threading.Tasks;
using JWTAuth.Models;

namespace JWTAuth.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(int userId);
        Task<List<User>> GetAllUsers();
        Task<User> CreateUserAsync(User newUser);
        Task<User> GetUserByIdAsync(int userId);
        Task<User> UpdateUserAsync(int userId, User updatedUser);
        Task<bool> DeleteUserAsync(int userId);
        System.Threading.Tasks.Task SaveChangesAsync();
    }
}
