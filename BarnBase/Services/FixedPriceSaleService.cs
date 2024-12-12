using AutoMapper;
using BarnBase.Dtos;
using BarnBase.Interfaces.Repository;
using BarnBase.Interfaces.Services;
using BarnBase.Models;
using BarnBase.Repository;

namespace BarnBase.Services
{
    public class FixedPriceSaleService : IFixedPriceSaleService
    {

        #region Fields
        private readonly IFixedPriceSaleRepository _fixedPriceSaleRepository;
        private readonly IMapper _mapper;
        #endregion Fields

        #region Public Constructors

        public FixedPriceSaleService(IFixedPriceSaleRepository fixedPriceSaleRepository, IMapper mapper)
        {
            _fixedPriceSaleRepository = fixedPriceSaleRepository;
            _mapper = mapper;

        }

        #endregion Public Constructors

        #region Public Methods
        public async Task AddFixedPriceSaleAsync(FixedPriceSaleDto fixedPriceSaleDto)
        {
            var sale = _mapper.Map<FixedPriceSale>(fixedPriceSaleDto);
            await _fixedPriceSaleRepository.AddFixedPriceSaleAsync(sale);
        }
        public async Task AddFavoritesSaleAsync(AddFavouriteSaleDto addFavouriteSaleDto)
        {
            var mapFavourite = _mapper.Map<FavouriteSale>(addFavouriteSaleDto);
            await _fixedPriceSaleRepository.AddFavoritesSaleAsync(mapFavourite);
        }

        public async Task<IEnumerable<FixedPriceSale>> GetAllFixedPriceSaleAsync()
        {
            return await _fixedPriceSaleRepository.GetAllFixedPriceSaleAsync();
        }

       public async Task<IEnumerable<FavouriteSale>> GetFavoritesSaleByUserIdAsync(int userId)
        {
            return await _fixedPriceSaleRepository.GetFavoritesSaleByUserIdAsync(userId);
        }

        public async Task<bool> DeleteFavouriteSaleAsync(int id)
        {
            return await _fixedPriceSaleRepository.DeleteFavouriteSaleAsync(id);
        }


        #endregion Public Methods
    }
}
