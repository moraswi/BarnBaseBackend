using BarnBase.Models;

namespace BarnBase.Interfaces.Repository
{
    public interface IFarmRepository
    {
        Task AddFarmAsync(Farm farm);

        Task<IEnumerable<Farm>> GetAllFarmsAsync();

        Task<Farm> GetFarmByIdAsync(int id);

        Task<IEnumerable<Farm>> GetFarmByUserIdAsync(int userId);

        Task<bool> DeleteFarmAsync(int id);
    }
}
