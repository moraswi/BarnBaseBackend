using BarnBase.Interfaces.Repository;
using BarnBase.Interfaces.Services;
using BarnBase.Models;

namespace BarnBase.Services
{
    public class FarmService : IFarmService
    {
        #region Fields
        private readonly IFarmRepository _farmRepository;
        #endregion Fields

        #region Public Constructors

        public FarmService(IFarmRepository farmRepository)
        {
            _farmRepository = farmRepository;

        }
        #endregion Public Constructors

        public async Task AddFarmAsync(Farm farm)
        {
            await _farmRepository.AddFarmAsync(farm);
        }

        public async Task<bool> DeleteFarmAsync(int id)
        {
            return await _farmRepository.DeleteFarmAsync(id);
        }

        public async Task<IEnumerable<Farm>> GetAllFarmsAsync()
        {
            return await _farmRepository.GetAllFarmsAsync();
        }

        public async Task<Farm> GetFarmByIdAsync(int id)
        {
           return await _farmRepository.GetFarmByIdAsync(id);
        }

        public async Task<IEnumerable<Farm>> GetFarmByUserIdAsync(int userId)
        {
            return await _farmRepository.GetFarmByUserIdAsync(userId);
        }
    }
}
