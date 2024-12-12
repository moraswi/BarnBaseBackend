using BarnBase.Dtos;
using BarnBase.Models;

namespace BarnBase.Interfaces.Services
{
    public interface IBreedingService
    {
        Task AddBreedingAsync(BreedingDto breedingDto);

        Task<IEnumerable<Breeding>> GetAllAuctionsAsync();

        Task<IEnumerable<Breeding>> GetBreedingByCategoryAsync(string category, int userId);

        Task<IEnumerable<Breeding>> GetBreedingByCowIdAsync(int cowId);
    }
}
