using BarnBase.Dtos;
using BarnBase.Interfaces.Services;
using BarnBase.Models;
using BarnBase.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarnBase.Controllers
{

    [Route("api/")]
    [ApiController]
    public class FixedPriceSaleController : ControllerBase
    {

        #region Fields
        private readonly IFixedPriceSaleService _fixedPriceSaleService;
        #endregion Fields

        #region Public Constructors
        public FixedPriceSaleController(IFixedPriceSaleService fixedPriceSaleService)
        {
            _fixedPriceSaleService = fixedPriceSaleService;
        }
        #endregion Public Constructors

        #region Public Methods

        [HttpPost("add-fixedpricesale")]
        public async Task<IActionResult> AddFixedPriceSale([FromBody] FixedPriceSaleDto fixedPriceSaleDto)
        {
            if (fixedPriceSaleDto == null)
            {
                return BadRequest(new { message = "FixedPriceSale object is null" });
            }

            await _fixedPriceSaleService.AddFixedPriceSaleAsync(fixedPriceSaleDto);

            return Ok(new { message = "Successfully created" });
        }

        [HttpPost("add-favourite")]
        public async Task<IActionResult> AddFixedPriceSaleAsync([FromBody] AddFavouriteSaleDto addFavouriteSaleDto)
        {
            await _fixedPriceSaleService.AddFavoritesSaleAsync(addFavouriteSaleDto);
            return Ok(addFavouriteSaleDto);
        }

        [HttpGet("get-all-fixedpricesale")]
        public async Task<IActionResult> GetAllFixedPriceSale()
        {
            var results = await _fixedPriceSaleService.GetAllFixedPriceSaleAsync();
            return Ok(results);
        }

        [HttpGet("get-favorites-byuserid/{userId}")]
        public async Task<IActionResult> GetFavoritesSaleByUserId(int userId)
        {
            var results = await _fixedPriceSaleService.GetFavoritesSaleByUserIdAsync(userId);
            if (results == null || !results.Any())
            {
                return NotFound();
            }

            return Ok(results);
        }

        [HttpDelete("delete-favorite/{favoriteId}")]
        public async Task<IActionResult> DeleteFavouriteSale(int favoriteId)
        {
            var results = await _fixedPriceSaleService.DeleteFavouriteSaleAsync(favoriteId);

            if (!results)
            {
                return BadRequest(new { message = "favorite object is null" });
            }
            return Ok(new { message = "Successfully deleted" });
        }
        #endregion Public Methods
    }
}
