using System.Collections.Generic;
using System.Threading.Tasks;
using JWTAuth.DTOs;
using JWTAuth.Models;
using JWTAuth.Services;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("{taskId}")]
        public async Task<ActionResult<Models.Task>> GetTaskById(int taskId)
        {
            var task = await _taskService.GetTaskById(taskId);

            if (task == null)
                return NotFound(); // Return 404 if task not found

            return Ok(task);
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.Task>>> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<ActionResult<Models.Task>> CreateTask([FromBody] TaskDTO newTask)
        {
            var createdTask = await _taskService.CreateTaskAsync(newTask);
            return CreatedAtAction(nameof(GetTaskById), new { taskId = createdTask.TaskId }, createdTask);
        }

        [HttpPut("{taskId}")]
        public async Task<ActionResult<Models.Task>> UpdateTask(int taskId, [FromBody] TaskDTO updatedTask)
        {
            var task = await _taskService.UpdateTaskAsync(taskId, updatedTask);

            if (task == null)
                return NotFound(); // Return 404 if task not found

            return Ok(task);
        }

        [HttpDelete("{taskId}")]
        public async Task<ActionResult<bool>> DeleteTask(int taskId)
        {
            var result = await _taskService.DeleteTaskAsync(taskId);

            if (!result)
                return NotFound(); // Return 404 if task not found

            return Ok(result);
        }
        [HttpGet("byUser/{userId}")]
        public async Task<ActionResult<List<Models.Task>>> GetTasksByUserId(int userId)
        {
            var tasks = await _taskService.GetTasksByUserId(userId);

            if (tasks == null || tasks.Count == 0)
                return NotFound(); // Return 404 if no tasks found

            return Ok(tasks);
        }

    }
}
