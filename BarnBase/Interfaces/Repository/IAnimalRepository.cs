using BarnBase.Dtos;
using BarnBase.Models;
using System.Threading.Tasks;

namespace BarnBase.Interfaces.Repository
{
    public interface IAnimalRepository
    {
        Task AddAnimalAsync(Animal animal);

        Task<IEnumerable<Animal>> GetAllAnimalsAsync();

        Task<Animal> GetAnimalByIdAsync(int id);

        Task<IEnumerable<Animal>> GetAnimalsByFarmIdAsync(int farmId);

        Task<bool> DeleteAnimalAsync(int id);

        Task AddAnimalWeightAsync(Weight weight);

        Task<IEnumerable<Weight>> GetWeightByAnimalIdAsync(int animalId);

        Task<IEnumerable<Weight>> GetWeightByAnimalTagNoAsync(string animalTagNo);

        Task<IEnumerable<AnimalAvrgWeightDto>> GetAnimalByGenderAvgWeightAsync(int farmId, string gender);

        Task<IEnumerable<AnimalAgeDto>> GetAnimalByGenderAgeAsync(int farmId, string gender);
        Task AddAnimalImageAsync(AnamilImage animalImage);
        Task<IEnumerable<AnamilImage>> GetImagesByAnimalIdAsync(int animalId);

        Task AddAnimalDocAsync(AnimalDocuments animalDocuments);
        Task<IEnumerable<AnimalDocuments>> GetDocByAnimalIdAsync(int animalId);

    }
}
