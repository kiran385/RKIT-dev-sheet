using Microsoft.AspNetCore.Mvc;
using WebAPICore.Models;

namespace WebAPICore.Controllers
{
    /// <summary>
    /// Task controller contains all API endpoints
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        static List<TodoItem> tasks = new List<TodoItem>
        {
            new TodoItem { Id=1, Title="C#", IsCompleted=true },
            new TodoItem { Id=2, Title="DBMS", IsCompleted=true},
            new TodoItem { Id=3, Title=".NET Core", IsCompleted=false}
        };

        /// <summary>
        /// Get all tasks
        /// </summary>
        /// <returns>List of tasks</returns>
        [HttpGet("get_tasks")]
        public IActionResult Get()
        {
            return Ok(tasks);
        }

        /// <summary>
        /// Get task by its id
        /// </summary>
        /// <param name="id">Task id</param>
        /// <returns>Task detail</returns>
        [HttpGet("get_task_by_id/{id}")]
        public IActionResult GetById(int id)
        {
            var task = tasks.Find(x => x.Id == id);
            if(task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        /// <summary>
        /// Add new task
        /// </summary>
        /// <param name="task">Task object</param>
        /// <returns>Appropriate status code with new task</returns>
        [HttpPost("~/Task/add_task")]
        public IActionResult Post([FromBody] TodoItem task)
        {
            tasks.Add(task);
            return StatusCode(201, task);
        }

        /// <summary>
        /// Update task
        /// </summary>
        /// <param name="id">Task id</param>
        /// <param name="updatedTask">Updated task object</param>
        /// <returns>Appropriate message whether task is updated or not</returns>
        [HttpPut("update_task/{id}")]
        public IActionResult Put(int id, [FromBody] TodoItem updatedTask)
        {
            var task = tasks.Find(x => x.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            task.Title = updatedTask.Title;
            task.IsCompleted = updatedTask.IsCompleted;
            return Ok(task);
        }

        /// <summary>
        /// Delete task by its id
        /// </summary>
        /// <param name="id">Task id</param>
        /// <returns>Appropriate message whether task is deleted or not</returns>
        [HttpDelete("delete_student/{id}")]
        public IActionResult Delete(int id)
        {
            var task = tasks.Find(x => x.Id ==id);
            if(task == null)
            {
                return NotFound();
            }
            tasks.Remove(task);
            return Ok();
        }
    }
}
