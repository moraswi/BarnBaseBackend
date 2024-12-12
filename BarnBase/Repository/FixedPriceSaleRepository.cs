using BarnBase.Data;
using BarnBase.Interfaces.Repository;
using BarnBase.Models;
using Microsoft.EntityFrameworkCore;

namespace BarnBase.Repository
{
    public class FixedPriceSaleRepository : IFixedPriceSaleRepository
    {

        #region Fields
        private readonly DataContext _context;
        #endregion Fields


        #region Public Constructors
        public FixedPriceSaleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddFavoritesSaleAsync(FavouriteSale favouriteSale)
        {
           await _context.FavouriteSale.AddAsync(favouriteSale);
           await _context.SaveChangesAsync();
        }
        #endregion Public Constructors



        #region Public Methods

        public async Task AddFixedPriceSaleAsync(FixedPriceSale FixedPriceSale)
        {
            await _context.FixedPriceSale.AddAsync(FixedPriceSale);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FixedPriceSale>> GetAllFixedPriceSaleAsync()
        {
            return await _context.FixedPriceSale.ToListAsync();
        }

        public async Task<IEnumerable<FavouriteSale>> GetFavoritesSaleByUserIdAsync(int userId)
        {
            return await _context.FavouriteSale.Where(f => f.UserId == userId).Include(f => f.FixedPriceSale).ToListAsync();
        }

        public async Task<bool> DeleteFavouriteSaleAsync(int id)
        {
           var results = await _context.FavouriteSale.FindAsync(id);

            if(results == null) {
                return true;
            }

            _context.FavouriteSale.Remove(results);
            _context.SaveChangesAsync();
            return true;
        }

        #endregion Public Methods

    }
}
