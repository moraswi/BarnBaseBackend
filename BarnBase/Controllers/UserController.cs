using Azure;
using BarnBase.Dtos;
using BarnBase.Interfaces.Services;
using BarnBase.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarnBase.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Fields
        private readonly IUserService _userService;
        #endregion Fields

        #region Public Constructors
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion Public Constructors

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LogInDto logInDto)
        {
            var results = await _userService.LoginAsync(logInDto);

            if (!results.Success)
            {
                return BadRequest(results.Message);
            }

            return StatusCode(200, results.Data);
        }


        [HttpPost("register-user")]
        public async Task<IActionResult> AddUser([FromBody] UserDto userDto)
        {
            await _userService.AddUserAsync(userDto);
            return Ok(userDto);
        }


        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.ChangePasswordAsync(changePasswordDto);
            if (!result)
            {
                return BadRequest("Failed to change password. Ensure the current password is correct.");
            }

            return Ok("Changed successfully.");
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPasswprd([FromBody] ForgotPasswordDto forgotPasswordDto)
        {
            var result = await _userService.ForgotPasswordPasswordAsync(forgotPasswordDto);

            if (!result)
            {
                return BadRequest("User not found or password update failed.");
            }

            return Ok("Updated successfully.");
        }

        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var results = await _userService.GetAllUserAsync();
            return Ok(results);
        }
    }
}
