using BarnBase.Data;
using BarnBase.Interfaces.Repository;
using BarnBase.Models;
using Microsoft.EntityFrameworkCore;

namespace BarnBase.Repository
{
    public class FarmRepository : IFarmRepository
    {
        #region Fields
        private readonly DataContext _context;
        #endregion Fields


        #region Public Constructors
        public FarmRepository(DataContext context)
        {
            _context = context;
        }
        #endregion Public Constructors


        #region Public Methods
        public async Task AddFarmAsync(Farm farm)
        {
            await _context.Farm.AddAsync(farm);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteFarmAsync(int id)
        {
            var farm = await _context.Farm.FindAsync(id);

            if (farm == null)
            {
                return false;
            }

            _context.Farm.Remove(farm);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Farm>> GetAllFarmsAsync()
        {
            return await _context.Farm.ToListAsync();
        }


        public async Task<Farm> GetFarmByIdAsync(int id)
        {
            return await _context.Farm.FindAsync(id);
        }

        async Task<IEnumerable<Farm>> IFarmRepository.GetFarmByUserIdAsync(int userId)
        {
            var response = await _context.Set<User>().AnyAsync(user => user.Id == userId);
            if (!response)
            {
                return null;
            }

            return await _context.Set<Farm>().Where(farm => farm.userId == userId).ToListAsync();
        }
        #endregion Public Methods

    }
}
