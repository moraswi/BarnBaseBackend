using BarnBase.Interfaces.Services;
using BarnBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BarnBase.Controllers
{
    [Route("api/")]
    [ApiController]
    public class FarmController : ControllerBase
    {

        #region Fields
        private readonly IFarmService _farmService;
        #endregion Fields

        #region Public Constructors
        public FarmController(IFarmService farmService)
        {
            _farmService = farmService;
        }
        #endregion Public Constructors

        #region Public Methods
        [HttpPost("add-farm")]
        public async Task<IActionResult> AddFarm([FromBody] Farm farm) 
        {
            if (farm == null)
            {
                return BadRequest(new { message = "Farm object is null" });
            }

            await _farmService.AddFarmAsync(farm);
            return Ok(farm);
        }

        [HttpGet("get-all-farms")]
        public async Task<IActionResult> GetAllFarms()
        {
            var results = await _farmService.GetAllFarmsAsync();

            return Ok(results);
        }

        [HttpGet("get-farm-byid/{id}")]
        public async Task<IActionResult> GetFarmById([FromRoute] int id)
        {
            var results = await _farmService.GetFarmByIdAsync(id);

            if(results == null)
            {
                return NotFound(new { message = "Farm not found" });
            }

            return Ok(results);
        }

        [HttpGet("get-farm-byuserid/{userId}")]
        public async Task<IActionResult> GetFarmByUserId(int userId)
        {
            var results = await _farmService.GetFarmByUserIdAsync(userId);

            if(results == null)
            {
                return NotFound(new { message = "User not found" });
            }

            return Ok(results);

        }



        [HttpDelete("delete-farm-byid/{id}")]
        public async Task<IActionResult> DeleteFarm(int id)
        {
            var results = await _farmService.DeleteFarmAsync(id);

            if (!results)
            {
                return NotFound(new { message = "Farm not found" });
            }

            return Ok(new { message = "Successfully deleted" });
        }



        #endregion Public Methods
    }
}
