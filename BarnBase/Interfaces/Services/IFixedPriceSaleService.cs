using BarnBase.Dtos;
using BarnBase.Models;

namespace BarnBase.Interfaces.Services
{
    public interface IFixedPriceSaleService
    {
        Task AddFixedPriceSaleAsync(FixedPriceSaleDto fixedPriceSaleDto);

        Task<IEnumerable<FixedPriceSale>> GetAllFixedPriceSaleAsync();

        Task AddFavoritesSaleAsync(AddFavouriteSaleDto addFavouriteSaleDto);

        Task<IEnumerable<FavouriteSale>> GetFavoritesSaleByUserIdAsync(int userId);

        Task<bool> DeleteFavouriteSaleAsync(int id);

    }
}
