using karavana_APPLICATION.InfraAbstractions;
using karavana_DOMAIN.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_INFRASTRUCTURE.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        private readonly ILogger<UserRepository> _logger;
        public UserRepository(AppDbContext context, ILogger<UserRepository> logger, UserManager<User> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<User> CreateUser(User user, string password)
        {
            try
            {
                user.UserName = GenerateRandomString();
                var result = await _userManager.CreateAsync(user, password);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }

            return await GetUserById(user.Id);
        }

        public async Task<User?> GetUserById(string userId)
        {
            var user = await _context.Users.Where(x=>x.Id == userId && !x.IsDeleted).SingleOrDefaultAsync();
            return user;
        }

        private string GenerateRandomString()
        {
            Random random = new Random();

            const string letters = "abcdefghijklmnopqrstuvwxyz";
            const string numbers = "0123456789";
            int letterLength = 8;
            int numberLength = 2;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < letterLength; i++)
            {
                sb.Append(letters[random.Next(letters.Length)]);
            }

            for (int i = 0; i < numberLength; i++)
            {
                sb.Append(numbers[random.Next(numbers.Length)]);
            }

            // Shuffle the characters to randomize their positions
            for (int i = sb.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                char temp = sb[j];
                sb[j] = sb[i];
                sb[i] = temp;
            }

            return sb.ToString();
        }
    }
}
