using BarnBase.Data;
using BarnBase.Interfaces.Repository;
using BarnBase.Models;
using Microsoft.EntityFrameworkCore;

namespace BarnBase.Repository
{
    public class BreedingRepository : IBreedingRepository
    {
        #region Fields
        private readonly DataContext _context;
        #endregion Fields

        #region Public Constructors
        public BreedingRepository(DataContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        public async Task AddBreedingAsync(Breeding breeding)
        {
            await _context.Breeding.AddAsync(breeding);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Breeding>> GetAllAuctionsAsync()
        {
            return await _context.Breeding.ToListAsync();
        }

        public async Task<IEnumerable<Breeding>> GetBreedingByCategoryAsync(string category, int userId)
        {
            return await _context.Set<Breeding>().Where(breeding => breeding.Category == category && breeding.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Breeding>> GetBreedingByCowIdAsync(int cowId)
        {
            return await _context.Set<Breeding>().Where(breeding => breeding.AnimalId == cowId).ToListAsync();
        }
    }
}
