using Business.DTOs;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Transactions;

namespace Business.Facades
{
    public class UserFacade
    {
        private readonly LogicalcDbContext _context;
        private const int PBKDF2IterCount = 100000;
        private const int PBKDF2SubkeyLength = 160 / 8;
        private const int saltSize = 128 / 8;

        public UserFacade(LogicalcDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<UserDto> RegisterUserAsync(UserLoginDto user)
        {
            await RegisterUser(user);
            return await LoginUserAsync(user);
        }

        public async Task<UserDto> LoginUserAsync(UserLoginDto user)
        {
            return await AuthorizeUserAsync(user);
        }

        public async Task<bool> UserExistsAsync(string userName)
        {
            return await _context.Users.CountAsync(x => x.UserName == userName) > 0;
        }

        #region auth
        private async Task<User?> GetUserAccordingToNameAsync(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
        }

        private async Task<UserDto> AuthorizeUserAsync(UserLoginDto login)
        {
            var user = await GetUserAccordingToNameAsync(login.UserName);
            if (user == null)
            {
                return null;
            }

            var (hash, salt) = user != null ? GetPassAndSalt(user.PasswordHash) : (string.Empty, string.Empty);

            var succ = user != null && VerifyHashedPassword(hash, salt, login.Password);
            if (succ)
            {
                return new UserDto() { UserName = user.UserName, Id= user.Id };
            }
            return null;
        }

        public async Task<Guid> RegisterUser(UserLoginDto user)
        {
            var (hash, salt) = CreateHash(user.Password);
            user.PasswordHash = string.Join(',', hash, salt);

            var dbUser = new User() { UserName = user.UserName, PasswordHash = user.PasswordHash};

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _context.Users.AddAsync(dbUser);
                await _context.SaveChangesAsync();
                scope.Complete();
            }


            return dbUser.Id;
        }

        private (string, string) GetPassAndSalt(string passwordHash)
        {
            var result = passwordHash.Split(',');
            if (result.Count() != 2)
            {
                return (string.Empty, string.Empty);
            }
            return (result[0], result[1]);
        }

        private bool VerifyHashedPassword(string hashedPassword, string salt, string password)
        {
            var hashedPasswordBytes = Convert.FromBase64String(hashedPassword);
            var saltBytes = Convert.FromBase64String(salt);

            using (var deriveBytes = new Rfc2898DeriveBytes(password, saltBytes, PBKDF2IterCount))
            {
                var generatedSubkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
                return hashedPasswordBytes.SequenceEqual(generatedSubkey);
            }
        }

        private Tuple<string, string> CreateHash(string password)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, saltSize, PBKDF2IterCount))
            {
                byte[] salt = deriveBytes.Salt;
                byte[] subkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);

                return Tuple.Create(Convert.ToBase64String(subkey), Convert.ToBase64String(salt));
            }
        }
        #endregion
    }
}
