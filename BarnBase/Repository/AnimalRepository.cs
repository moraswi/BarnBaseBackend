using BarnBase.Data;
using BarnBase.Dtos;
using BarnBase.Interfaces.Repository;
using BarnBase.Models;
using BarnBase.Models;
using Microsoft.EntityFrameworkCore;

namespace BarnBase.Repository
{
    public class AnimalRepository : IAnimalRepository
    {
        #region Fields
        private readonly DataContext _context;
        #endregion Fields


        #region Public Constructors
        public AnimalRepository(DataContext context)
        {
            _context = context;
        }
        #endregion Public Constructors


        #region Public Methods

        public async Task AddAnimalAsync(Animal animal)
        {
            await _context.Animal.AddAsync(animal);
            await _context.SaveChangesAsync();
        }

        public async Task AddAnimalWeightAsync(Weight weight)
        {
           await _context.Weight.AddAsync(weight);
           await _context.SaveChangesAsync();
        }

        public async Task<Animal> GetAnimalByIdAsync(int id)
        {
            return await _context.Animal.FindAsync(id);
        }

        public async Task<bool> DeleteAnimalAsync(int id)
        {
            var animal = await _context.Animal.FindAsync(id);

            if(animal == null)
            {
                return false;
            }

            _context.Animal.Remove(animal);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Animal>> GetAnimalsByFarmIdAsync(int farmId)
        {
            var farmExists = await _context.Set<Farm>().AnyAsync(farm => farm.Id == farmId);
            if (!farmExists)
            {
                return null;
            }

            return await _context.Set<Animal>().Where(animal => animal.FarmId == farmId).ToListAsync();
        }


        public async Task<IEnumerable<Animal>> GetAllAnimalsAsync()
        {
            return await _context.Animal.ToListAsync();
        }

        public async Task<IEnumerable<Weight>> GetWeightByAnimalIdAsync(int animalId)
        {
            var animalExists = await _context.Set<Animal>().AnyAsync(animal => animal.Id == animalId);
            if(!animalExists)
            {
                return null;
            }

            return await _context.Set<Weight>().Where(weight => weight.AnimalId == animalId).ToListAsync();
        }

        public async Task<IEnumerable<Weight>> GetWeightByAnimalTagNoAsync(string animalTagNo)
        {
           return await _context.Set<Weight>().Where(weight => weight.MotherTagNo == animalTagNo).ToListAsync();
        }

        public async Task<IEnumerable<AnimalAvrgWeightDto>> GetAnimalByGenderAvgWeightAsync(int farmId, string gender)
        {
            return await _context.Animal
                .Where(c => c.FarmId == farmId && c.Sex == gender)
                .Select(c => new AnimalAvrgWeightDto
                {
                    Id = c.Id,
                    FarmId = c.FarmId,
                    Sex = c.Sex,
                    AverageWeight = _context.Weight
                                      .Where(w => w.AnimalId == c.Id)
                                      .Average(w => (double?)w.AnimalWeight)
                }).ToListAsync();
        }

        public async Task<IEnumerable<AnimalAgeDto>> GetAnimalByGenderAgeAsync(int farmId, string gender)
        {
            var animals = await _context.Set<Animal>()
                .Where(x => x.FarmId == farmId && x.Sex == gender)
                .ToListAsync();

            return animals.Select(c => new AnimalAgeDto
            {
                Id = c.Id,
                FarmId = c.FarmId,
                Sex = c.Sex,
                Age = CalculateAnimalAge(c.DateOfBirth)
            });
        }

        private static string CalculateAnimalAge(DateTime dateOfBirth)
        {
            var ageSpan = DateTime.Now - dateOfBirth;

            if (ageSpan.Days < 30)
                return $"{ageSpan.Days} days";
            else if (ageSpan.Days < 365)
                return $"{ageSpan.Days / 30} months";
            else
                return $"{ageSpan.Days / 365} years";
        }

        public async Task AddAnimalImageAsync(AnamilImage animalImage)
        {
            _context.AnimalImage.AddAsync(animalImage);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<AnamilImage>> GetImagesByAnimalIdAsync(int animalId)
        {
           return await _context.Set<AnamilImage>().Where(x => x.AnimalId == animalId).ToListAsync();
        }

        public async Task AddAnimalDocAsync(AnimalDocuments animalDocuments)
        {
            _context.AnimalDocuments.AddAsync(animalDocuments);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<AnimalDocuments>> GetDocByAnimalIdAsync(int animalId)
        {
            return await _context.Set<AnimalDocuments>().Where(x => x.AnimalId == animalId).ToListAsync();
        }

        #endregion Public Methods
    }
}
