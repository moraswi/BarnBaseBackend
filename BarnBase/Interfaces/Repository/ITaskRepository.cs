//using BarnBase.Dtos;
using BarnBase.Models;

namespace BarnBase.Interfaces.Repository
{
    public interface ITaskRepository
    {
        Task AddTaskAsync(NoteTask noteTask);

        Task<NoteTask> UpdateTaskAsync(NoteTask noteTask);

        Task<IEnumerable<NoteTask>> GetAllTaskAsync();

        Task<NoteTask> GetTaskByIdAsync(int id);

        Task<IEnumerable<NoteTask>> GetTaskByUserIdAsync(int userId);

        Task<bool> DeleteTaskAsync(int id);

    }
}
