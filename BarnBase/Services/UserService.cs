using AutoMapper;
using BarnBase.Class;
using BarnBase.Dtos;
using BarnBase.Interfaces.Repository;
using BarnBase.Interfaces.Services;
using BarnBase.Models;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace BarnBase.Services
{
    public class UserService : IUserService
    {
        #region Fields
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        #endregion Fields

        #region Public Constructors

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;

        }
        #endregion Public Constructors


        #region Public Methods

        public async Task AddUserAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            await _userRepository.AddUserAsync(user);
        }

        public async Task<bool> ChangePasswordAsync(ChangePasswordDto changePasswordDto)
        {
            var user = await _userRepository.GetUsersByIdAsync(changePasswordDto.UserId);

            if(user == null || VerifyPassword(changePasswordDto.CurrentPassword, user.Password))
            {
                return false;
            }

            return await _userRepository.ChangePasswordAsync(changePasswordDto.UserId, changePasswordDto.NewPassword);
        }

        public async Task<bool> ForgotPasswordPasswordAsync(ForgotPasswordDto forgotPasswordDto)
        {
            var user = await _userRepository.GetUserByEmailAsync(forgotPasswordDto.Email);

            if (user == null)
            {
                return false;
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(forgotPasswordDto.NewPassword);

            await _userRepository.ForgotPasswordPasswordAsync(user, hashedPassword);
            return true;
        }


        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await _userRepository.GetAllUserAsync();
        }

        public async Task<ServiceResponse<UserLoginDto>> LoginAsync(LogInDto logInDto)
        {
            var response = new ServiceResponse<UserLoginDto>();

             var user = await _userRepository.GetUserByUsernameAsync(logInDto.UserName);
            if (user == null || !VerifyPassword(logInDto.Password, user.Password))
                {
                response.Success = false;
                response.Message = "Invalid username or password.";
                return response;
            }

            var userResponse = _mapper.Map<UserLoginDto>(user);

            response.Data = userResponse;
            response.Success = true;
            return response;

        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        private bool IsValidEmail(string input)
        {
            // A basic email validation regex
            return Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
        private static bool VerifyPassword(string currentPassword, string storedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(currentPassword, storedPassword);
        }

        #endregion Public Methods
    }
}
