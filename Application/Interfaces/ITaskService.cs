using Model.Model;

namespace Application.Interfaces;

public interface ITaskService
{
    Task AddTask(TaskModel model);
    Task DeleteTask(Guid id);
    Task UpdateTask(TaskModel model);
    Task<TaskModel> GetTaskById(Guid id); 
    Task<IEnumerable<TaskModel>> GetAllTasks();
}
