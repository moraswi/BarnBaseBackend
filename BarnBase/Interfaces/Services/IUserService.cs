using BarnBase.Class;
using BarnBase.Dtos;
using BarnBase.Models;

namespace BarnBase.Interfaces.Services
{
    public interface IUserService
    { 
         Task AddUserAsync(UserDto userDto);
        Task<ServiceResponse<UserLoginDto>> LoginAsync(LogInDto logInDto);
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<bool> ChangePasswordAsync(ChangePasswordDto changePasswordDto);
        Task<User> GetUserByEmailAsync(string email);

        Task<bool> ForgotPasswordPasswordAsync(ForgotPasswordDto forgotPasswordDto);
    }
}
