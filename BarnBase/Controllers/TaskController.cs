using BarnBase.Dtos;
using BarnBase.Interfaces.Repository;
using BarnBase.Interfaces.Services;
using BarnBase.Models;
using BarnBase.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarnBase.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        #region Fields
        private readonly ITaskService _taskService;
        #endregion Fields

        #region Public Constructors
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        #endregion Public Constructors

        [HttpPost("add-task")]
        public async Task<IActionResult> AddTask([FromBody] TaskDto taskDto)
        {
            await _taskService.AddTaskAsync(taskDto);
            return Ok( taskDto);
        }

        [HttpGet("get-all-task")]
        public async Task<IActionResult> GetAllTask()
        {
            var results = await _taskService.GetAllTaskAsync();
            return Ok(results);
        }

        [HttpGet("get-task-byuserid/{userid}")]
        public async Task<IActionResult> GetTaskByUserId(int userid)
        {
            var results = await _taskService.GetTaskByUserIdAsync(userid);
            return Ok(results);
        }

        [HttpGet("get-task-byid/{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var results = await _taskService.GetTaskByIdAsync(id);
            return Ok(results);
        }


        [HttpPut("update-task")]
        public async Task<IActionResult> UpdateTask([FromBody] NoteTask noteTask)
        {
            var results = await _taskService.UpdateTaskAsync(noteTask);
            return Ok(results);
        }

        [HttpDelete("delete-task/{taskId}")]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            var results = await _taskService.DeleteTaskAsync(taskId);

            if (!results)
            {
                return BadRequest(new { message = "Task object is null" });
            }
            return Ok(new { message = "Successfully deleted" });
        }

    }
}
