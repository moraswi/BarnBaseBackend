
using BarnBase.Dtos;
using BarnBase.Models;

namespace BarnBase.Interfaces.Services
{
    public interface IAnimalService
    {

        Task AddAnimalAsync(AnimalDto animalDto);

        Task<IEnumerable<Animal>> GetAllAnimalsAsync();

        Task<Animal> GetAnimalByIdAsync(int id);

        Task<IEnumerable<Animal>> GetAnimalsByFarmIdAsync(int farmId);

        Task<bool> DeleteAnimalAsync(int id);

        Task AddAnimalWeightAsync(WeightDto weightDto);

        Task<IEnumerable<Weight>> GetWeightByAnimalIdAsync(int animalId);

        Task<IEnumerable<Weight>> GetWeightByAnimalTagNoAsync(string animalTagNo);

        Task<IEnumerable<AnimalAvrgWeightDto>> GetAnimalByGenderAvgWeightAsync(int farmId, string gender);

        Task<IEnumerable<AnimalAgeDto>> GetAnimalByGenderAgeAsync(int farmId, string gender);
        Task AddAnimalImageAsync(AnimalImageDto animalImageDto);
        Task<IEnumerable<AnamilImage>> GetImagesByAnimalIdAsync(int animalId);

        Task AddAnimalDocAsync(AnimalDocumentDto animalDocumentDto);
        Task<IEnumerable<AnimalDocuments>> GetDocByAnimalIdAsync(int animalId);

        // Task AddBreedingAsync(BreedingDto breedingDto);

    }
}
