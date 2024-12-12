using AutoMapper;
using BarnBase.Dtos;
using BarnBase.Interfaces.Repository;
using BarnBase.Interfaces.Services;
using BarnBase.Models;

namespace BarnBase.Services
{
    public class TaskService : ITaskService
    {
        #region Fields
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        #endregion Fields

        #region Public Constructors

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;

        }

        public async Task AddTaskAsync(TaskDto taskDto)
        {
            var mapTask = _mapper.Map<NoteTask>(taskDto);
            await _taskRepository.AddTaskAsync(mapTask);
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
           return await _taskRepository.DeleteTaskAsync(id);
        }

        public async Task<IEnumerable<NoteTask>> GetAllTaskAsync()
        {
            return await _taskRepository.GetAllTaskAsync();
        }

        public Task<NoteTask> GetTaskByIdAsync(int id)
        {
           return _taskRepository.GetTaskByIdAsync(id);
        }

        public Task<IEnumerable<NoteTask>> GetTaskByUserIdAsync(int userId)
        {
            return _taskRepository.GetTaskByUserIdAsync(userId);
        }

        public async Task<NoteTask> UpdateTaskAsync(NoteTask noteTask)
        {
            return await _taskRepository.UpdateTaskAsync(noteTask);
        }

        #endregion Public Constructors
    }
}
