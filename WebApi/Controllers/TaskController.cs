using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Model;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;
    public TaskController(ITaskService taskService)
    {
        _taskService = taskService; 
    }

    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
        try
        {
            var result = await _taskService.GetAllTasks();
            return Ok(result);
        }
        catch (Exception ex) { throw ex; }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskById(Guid id)
    {
        try
        {
            var result = await _taskService.GetTaskById(id);
            return Ok(result);
        }
        catch (Exception ex) { throw ex; }
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] TaskModel model)
    {
        try
        {
            await _taskService.AddTask(model);
            return Ok();
        }
        catch (Exception ex) { throw ex; }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(Guid id)
    {
        try
        {
            await _taskService.DeleteTask(id);
            return Ok();
        }
        catch (Exception ex) { throw ex; }
    }

}
