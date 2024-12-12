using BarnBase.Models;

namespace BarnBase.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);

        Task<IEnumerable<User>> GetAllUserAsync();

        Task<User> GetUserByUsernameAsync(string username);

        Task<User> GetUsersByIdAsync(int userId);

        Task<User> GetUserByEmailAsync(string email);

        Task<User> GetUserByPhoneNumberAsync(string phoneNumber);
        Task<bool> ChangePasswordAsync(int userID, string newPassword);

        Task ForgotPasswordPasswordAsync(User user, string newPassword);
    }
}
