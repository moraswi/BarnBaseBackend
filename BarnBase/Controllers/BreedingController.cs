using BarnBase.Dtos;
using BarnBase.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarnBase.Controllers
{
    [Route("api/")]
    [ApiController]
    public class BreedingController : ControllerBase
    {

        #region Fields
        private readonly IBreedingService _breedingService;
        #endregion Fields

        #region Public Constructors
        public BreedingController(IBreedingService breedingService)
        {
            _breedingService = breedingService;
        }
        #endregion Public Constructors

        [HttpPost("add-breeding")]
        public async Task<IActionResult> AddBreeding([FromBody] BreedingDto breedingDto) {
            await _breedingService.AddBreedingAsync(breedingDto);
            return Ok(breedingDto);
        }

        [HttpGet("get-all-breeding")]
        public async Task<IActionResult> GetAllBreeding() {
            var breeding = await _breedingService.GetAllAuctionsAsync();
            return Ok(breeding);
        }

        [HttpGet("get-breeding-bycategory/{category}/userId")]
        public async Task<IActionResult> GetBreedingByCategory(String category, int userId)
        {
            var breeding = await _breedingService.GetBreedingByCategoryAsync(category, userId);
            return Ok(breeding);
        }

        [HttpGet("get-breeding-bycategory/{cowId}")]
        public async Task<IActionResult> GetBreedingByCowId( int cowId)
        {
            var breeding = await _breedingService.GetBreedingByCowIdAsync(cowId);
            return Ok(breeding);
        }
    }
}
