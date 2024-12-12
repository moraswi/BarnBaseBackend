using BarnBase.Data;
using BarnBase.Interfaces.Repository;
using BarnBase.Models;
using Microsoft.EntityFrameworkCore;

namespace BarnBase.Repository
{
    public class TaskRepository : ITaskRepository
    {
        #region Fields
        private readonly DataContext _context;
        #endregion Fields


        #region Public Constructors
        public TaskRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddTaskAsync(NoteTask noteTask)
        {
            await _context.NoteTask.AddAsync(noteTask);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var results = await _context.NoteTask.FindAsync(id);

            if (results == null)
            {
                return false;
            }

            _context.NoteTask.Remove(results);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<NoteTask>> GetAllTaskAsync()
        {
            return await _context.NoteTask.ToListAsync();
        }

        public async Task<NoteTask> GetTaskByIdAsync(int id)
        {
            var results = await _context.NoteTask.FindAsync(id);
            return results;
        }

        async Task<IEnumerable<NoteTask>> ITaskRepository.GetTaskByUserIdAsync(int userId)
        {
            var results = await _context.Set<NoteTask>().Where(x => x.UserId == userId).ToListAsync();
            return results;
        }


        public async Task<NoteTask> UpdateTaskAsync(NoteTask noteTask)
        {
            _context.NoteTask.Update(noteTask);
            await _context.SaveChangesAsync();
            return noteTask;
        }



        #endregion Public Constructors
    }
}
