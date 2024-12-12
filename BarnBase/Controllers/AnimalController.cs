using BarnBase.Data;
//using BarnBase.Dtos;
using BarnBase.Interfaces.Repository;
using BarnBase.Interfaces.Services;
using BarnBase.Services;
using BarnBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using BarnBase.Dtos;
using System.Reflection;

namespace BarnBase.Controllers
{

    [Route("api/")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        #region Fields
        private readonly IAnimalService _animalService;
        #endregion Fields

        #region Public Constructors
        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }
        #endregion Public Constructors

        #region Public Methods

        [HttpPost("add-animal")]
        public async Task<IActionResult> Addanimal([FromBody] AnimalDto animalDto)
        {
            await _animalService.AddAnimalAsync(animalDto);
            return Ok(animalDto);
        }

        [HttpPost("add-animal-image")]
        public async Task<IActionResult> AddAnimalImage([FromBody] AnimalImageDto animalImageDto)
        {
            await _animalService.AddAnimalImageAsync(animalImageDto);
            return Ok(animalImageDto);
        }

        [HttpPost("add-animal-Doc")]
        public async Task<IActionResult> AddAnimalDoc([FromBody] AnimalDocumentDto animalDocumentDto)
        {
            await _animalService.AddAnimalDocAsync(animalDocumentDto);
            return Ok(animalDocumentDto);
        }

        [HttpPost("add-animal-weight")]
        public async Task<IActionResult> AddAnimalWeight([FromBody] WeightDto weightDto)
        {
            await _animalService.AddAnimalWeightAsync(weightDto);
            return Ok(new { message = "Successfully created" });

        }
        [HttpGet("get-all-animal")]
        public async Task<IActionResult> GetAllAnimals()
        {
            var animals = await _animalService.GetAllAnimalsAsync();

            return Ok(animals);
        }


        [HttpGet("get-animal-byid/{id}")]
        public async Task<IActionResult> GetAnimalById([FromRoute] int id) 
        {
             var animal = await _animalService.GetAnimalByIdAsync(id);

            if(animal == null)
            {
                return NotFound(new { message = "animal not found" });
            }

            return Ok(animal);
        }

        [HttpGet("get-animal-byfarmid/{farmId}")]
        public async Task<IActionResult> GetAnimalsByFarmId(int farmId)
        {
            var animals = await _animalService.GetAnimalsByFarmIdAsync(farmId);
            if (animals == null)
            {
                return NotFound(new { message = "Farm not found" });
            }

            return Ok(animals);
        }

        [HttpDelete("delete-animal-byid/{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            var isDeleted = await _animalService.DeleteAnimalAsync(id);

            if (!isDeleted)
            {
                return NotFound(new { message = "animal not found" });
            }

            return Ok(new { message = "Successfully deleted" });
        }



        [HttpGet("get-weight-byanimalid/{animalId}")]
        public async Task<IActionResult> GetWeightByAnimalId(int animalId) {
            var weight = await _animalService.GetWeightByAnimalIdAsync(animalId);

            if(weight == null)
            {
                return NotFound(new { message = "animal not found" });
            }

            return Ok(weight);
        }

        [HttpGet("get-weight-bymothertagno/{animalTagNo}")]
        public async Task<IActionResult> GetWeightByMotherTagNo(string animalTagNo) {

            var weight = await _animalService.GetWeightByAnimalTagNoAsync(animalTagNo);

            if (weight == null)
            {
                return NotFound(new { message = "animal not found" });
            }

            return Ok(weight);
        }

        [HttpGet("get-animal-avgweight-bygender/{farmId}/{gender}")]
        public async Task<IActionResult> GetAnimalByGenderAvgWeight([FromRoute] int farmId, string gender)
        {

            var results = await _animalService.GetAnimalByGenderAvgWeightAsync(farmId, gender);

            if (results == null)
            {
                return NotFound(new { message = "not found" });
            }

            return Ok(results);
        }

        [HttpGet("get-animal-age-bygender/{farmId}/{gender}")]
        public async Task<IActionResult> GetAnimalByGenderAgeAsync([FromRoute] int farmId, string gender)
        {

            var results = await _animalService.GetAnimalByGenderAgeAsync(farmId, gender);

            if (results == null)
            {
                return NotFound(new { message = "not found" });
            }

            return Ok(results);
        }

        [HttpGet("get-animal-image/{animalId}")]
        public async Task<IActionResult> GetAnimalImage([FromRoute] int animalId)
        {
            var results = await _animalService.GetImagesByAnimalIdAsync(animalId);
            if (results == null)
            {
                return NotFound(new { message = "not found" });
            }

            return Ok(results);
        }


        [HttpGet("get-animal-Doc/{animalId}")]
        public async Task<IActionResult> GetAnimalDoc([FromRoute] int animalId)
        {
            var results = await _animalService.GetDocByAnimalIdAsync(animalId);
            if (results == null)
            {
                return NotFound(new { message = "not found" });
            }

            return Ok(results);
        }


        #endregion Public Methods
    }
}
