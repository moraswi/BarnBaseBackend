using BarnBase.Dtos;
using BarnBase.Models;

namespace BarnBase.Interfaces.Services
{
    public interface ITaskService
    {
        Task AddTaskAsync(TaskDto taskDto);

        Task<NoteTask> UpdateTaskAsync(NoteTask noteTask);

        Task<IEnumerable<NoteTask>> GetAllTaskAsync();

        Task<NoteTask> GetTaskByIdAsync(int id);

        Task<IEnumerable<NoteTask>> GetTaskByUserIdAsync(int userId);

        Task<bool> DeleteTaskAsync(int id);

    }
}
