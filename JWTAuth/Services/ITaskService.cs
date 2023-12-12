using JWTAuth.DTOs;
using JWTAuth.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JWTAuth.Services
{
    public interface ITaskService
    {
        Task<Models.Task> GetTaskById(int taskId);
        Task<List<Models.Task>> GetAllTasks();
        Task<Models.Task> CreateTaskAsync(TaskDTO newTask);
        Task<Models.Task> UpdateTaskAsync(int taskId, TaskDTO updatedTask);
        Task<bool> DeleteTaskAsync(int taskId);
        System.Threading.Tasks.Task SaveChangesAsync();
    }
}
