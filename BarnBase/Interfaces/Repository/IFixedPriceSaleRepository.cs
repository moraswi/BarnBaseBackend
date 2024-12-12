using BarnBase.Models;

namespace BarnBase.Interfaces.Repository
{
    public interface IFixedPriceSaleRepository
    {
        Task AddFixedPriceSaleAsync(FixedPriceSale FixedPriceSale);

        Task<IEnumerable<FixedPriceSale>> GetAllFixedPriceSaleAsync();

        Task AddFavoritesSaleAsync(FavouriteSale favouriteSale);

        Task<IEnumerable<FavouriteSale>> GetFavoritesSaleByUserIdAsync(int userId);

        Task<bool> DeleteFavouriteSaleAsync(int id);

    }
}
