using AutoMapper;
using BarnBase.Dtos;
using BarnBase.Interfaces.Repository;
using BarnBase.Interfaces.Services;
using BarnBase.Models;

namespace BarnBase.Services
{
    public class BreedingService : IBreedingService
    {
        #region Fields
        private readonly IBreedingRepository _breedingRepository;
        private readonly IMapper _mapper;
        #endregion Fields

        #region Public Constructors
        public BreedingService(IBreedingRepository breedingRepository, IMapper mapper)
        {
            _breedingRepository = breedingRepository;
            _mapper = mapper;
        }
        #endregion Public Constructors

        public async Task AddBreedingAsync(BreedingDto breedingDto)
        {
            var breeding = _mapper.Map<Breeding>(breedingDto);
            await _breedingRepository.AddBreedingAsync(breeding);
        }

        public async Task<IEnumerable<Breeding>> GetAllAuctionsAsync()
        {
            return await _breedingRepository.GetAllAuctionsAsync();
        }

        public async Task<IEnumerable<Breeding>> GetBreedingByCategoryAsync(string category, int userId)
        {
            return await _breedingRepository.GetBreedingByCategoryAsync(category, userId);
        }

        public async Task<IEnumerable<Breeding>> GetBreedingByCowIdAsync(int cowId)
        {
            return await _breedingRepository.GetBreedingByCowIdAsync(cowId);
        }
    }
}
