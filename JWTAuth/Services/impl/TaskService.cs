using System.Collections.Generic;
using System.Threading.Tasks;
using JWTAuth.DTOs;
using JWTAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.Services
{
    public class TaskService : ITaskService
    {
        private readonly DataContext _dbContext;

        public TaskService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Models.Task> GetTaskById(int taskId)
        {
            return await _dbContext.Tasks.FindAsync(taskId);
        }

        public async Task<List<Models.Task>> GetAllTasks()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<Models.Task> CreateTaskAsync(TaskDTO newTaskDTO)
        {
            var newTask = new Models.Task
            {
                Title = newTaskDTO.Title,
                Description = newTaskDTO.Description,
                AssignedToUserId = newTaskDTO.AssignedToUserId,
                DueDate = newTaskDTO.DueDate,
                Status = newTaskDTO.Status
            };
            _dbContext.Tasks.Add(newTask);
            await SaveChangesAsync();
            return newTask;
        }


        public async Task<Models.Task> UpdateTaskAsync(int taskId, TaskDTO updatedTask)
        {
            if (updatedTask == null)
                return null; // Invalid or null DTO

            var existingTask = await _dbContext.Tasks.FindAsync(taskId);

            if (existingTask == null)
                return null; // Task not found

            // Update properties
            existingTask.Title = updatedTask.Title;
            existingTask.Description = updatedTask.Description;
            existingTask.AssignedToUserId = updatedTask.AssignedToUserId;
            existingTask.DueDate = updatedTask.DueDate;
            existingTask.Status = updatedTask.Status;

            await SaveChangesAsync();
            return existingTask;
        }

        public async Task<bool> DeleteTaskAsync(int taskId)
        {
            var taskToDelete = await _dbContext.Tasks.FindAsync(taskId);

            if (taskToDelete == null)
                return false; // Task not found

            _dbContext.Tasks.Remove(taskToDelete);
            await SaveChangesAsync();
            return true;
        }

        public async System.Threading.Tasks.Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
