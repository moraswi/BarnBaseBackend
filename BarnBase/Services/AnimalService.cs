using AutoMapper;
using BarnBase.Dtos;
using BarnBase.Interfaces.Repository;
using BarnBase.Interfaces.Services;
using BarnBase.Models;
using System.Reflection;

namespace BarnBase.Services
{
    public class AnimalService : IAnimalService
    {
        #region Fields
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper;
        #endregion Fields

        #region Public Constructors

        public AnimalService(IAnimalRepository animalRepository, IMapper mapper)
        {
            _animalRepository = animalRepository;
            _mapper = mapper;

        }
        #endregion Public Constructors


        #region Public Methods

        public async Task AddAnimalAsync(AnimalDto animalDto)
        {
            var animal = _mapper.Map<Animal>(animalDto);
            await _animalRepository.AddAnimalAsync(animal);
        }

        public async Task<IEnumerable<Animal>> GetAllAnimalsAsync()
        {
          return  await _animalRepository.GetAllAnimalsAsync();
        }

        public async Task<Animal> GetAnimalByIdAsync(int id)
        {
           return await _animalRepository.GetAnimalByIdAsync(id);
        }

        public async Task<bool> DeleteAnimalAsync(int id)
        {
            return await _animalRepository.DeleteAnimalAsync(id);
        }

        public async Task<IEnumerable<Animal>> GetAnimalsByFarmIdAsync(int farmId)
        {
            return await _animalRepository.GetAnimalsByFarmIdAsync(farmId);
        }

        public async Task AddAnimalWeightAsync(WeightDto weightDto)
        {
            var weight = _mapper.Map<Weight>(weightDto);
            await _animalRepository.AddAnimalWeightAsync(weight);
        }

        public async Task<IEnumerable<Weight>> GetWeightByAnimalIdAsync(int animalId)
        {
            return await _animalRepository.GetWeightByAnimalIdAsync(animalId);
        }

        public async Task<IEnumerable<Weight>> GetWeightByAnimalTagNoAsync(string animalTagNo)
        {
           return await _animalRepository.GetWeightByAnimalTagNoAsync(animalTagNo);
        }

        public async Task<IEnumerable<AnimalAvrgWeightDto>> GetAnimalByGenderAvgWeightAsync(int farmId, string gender)
        {
            return await _animalRepository.GetAnimalByGenderAvgWeightAsync(farmId, gender);
        }

        public async Task<IEnumerable<AnimalAgeDto>> GetAnimalByGenderAgeAsync(int farmId, string gender)
        {
            return await _animalRepository.GetAnimalByGenderAgeAsync(farmId, gender);
        }

        public async Task<IEnumerable<AnamilImage>> GetImagesByAnimalIdAsync(int animalId)
        {
            return await _animalRepository.GetImagesByAnimalIdAsync(animalId);
        }

        public async Task AddAnimalImageAsync(AnimalImageDto animalImageDto)
        {
            var mapedAnimalImage = _mapper.Map<AnamilImage>(animalImageDto);
            await _animalRepository.AddAnimalImageAsync(mapedAnimalImage);
        }

        public async Task AddAnimalDocAsync(AnimalDocumentDto animalDocumentDto)
        {
            var  mapedAnimalDoc = _mapper.Map<AnimalDocuments>(animalDocumentDto);
            await _animalRepository.AddAnimalDocAsync(mapedAnimalDoc);
        }

        public async Task<IEnumerable<AnimalDocuments>> GetDocByAnimalIdAsync(int animalId)
        {
            return await _animalRepository.GetDocByAnimalIdAsync(animalId);
        }

        #endregion Public Methods
    }

}
