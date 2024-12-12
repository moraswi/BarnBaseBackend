using BarnBase.Models;

namespace BarnBase.Interfaces.Repository
{
    public interface IBreedingRepository
    {
        Task AddBreedingAsync(Breeding breeding);

        Task<IEnumerable<Breeding>> GetAllAuctionsAsync();

        Task<IEnumerable<Breeding>> GetBreedingByCategoryAsync(string category, int userId);

        Task<IEnumerable<Breeding>> GetBreedingByCowIdAsync(int cowId);
    }
}
