using BarnBase.Models;

namespace BarnBase.Interfaces.Services
{
    public interface IFarmService
    {
        Task AddFarmAsync(Farm farm);

        Task<IEnumerable<Farm>> GetAllFarmsAsync();

        Task<Farm> GetFarmByIdAsync(int id);

        Task<IEnumerable<Farm>> GetFarmByUserIdAsync(int userId);

        Task<bool> DeleteFarmAsync(int id);
    }
}
