using BarnBase.Data;
using BarnBase.Interfaces.Repository;
using BarnBase.Models;
using Microsoft.EntityFrameworkCore;
using System.Web.Helpers;

namespace BarnBase.Repository
{
    public class UserRepository : IUserRepository
    {
        #region Fields
        private readonly DataContext _context;
        #endregion Fields

        #region Public Constructors
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        #endregion Public Constructors


        #region Public Methods

        public async Task AddUserAsync(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ChangePasswordAsync(int userID, string newPassword)
        {
            var user = await GetUsersByIdAsync(userID);
            if(user == null)
            {
                return false;
            }

            user.Password = HashPassword(newPassword);

            _context.User.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }

        private string HashPassword(string password)
        {
            return password;
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByPhoneNumberAsync(string phoneNumber)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<User> GetUsersByIdAsync(int userId)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task ForgotPasswordPasswordAsync(User user, string newPassword)
        {
            user.Password = newPassword;
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }
        #endregion Public Methods
    }
}
