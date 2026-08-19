using Application.Interfaces;
using Model.Interfaces;
using Model.Model;

namespace Application.Servises;

class TaskService : ITaskService
{
    private readonly IRepository<TaskModel> _taskRepository;
    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    public async Task AddTask(TaskModel model)
    {
        try
        {
            await _taskRepository.AddAsync(model);
            _taskRepository.SaveChanges();
        }
        catch (Exception ex) { throw ex; }
    }

    public async Task DeleteTask(Guid id)
    {
        try
        {
            _taskRepository.Remove(id);
            _taskRepository.SaveChanges();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<IEnumerable<TaskModel>> GetAllTasks()
    {
        return await _taskRepository.AllAsync();
    }

    public async Task<TaskModel> GetTaskById(Guid id)
    {
        return await _taskRepository.FindAsync(id);
    }

    public async Task UpdateTask(TaskModel model)
    {
        try
        {
            _taskRepository.Update(model);
            _taskRepository.SaveChanges();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
