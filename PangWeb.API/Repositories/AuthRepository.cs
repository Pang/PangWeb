using PangWeb.API.Data;
using PangWeb.Shared;
using Microsoft.EntityFrameworkCore;
using PangWeb.API.Repositories.Interfaces;
using PangWeb.Shared.DTOs;

namespace PangWeb.API.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> Login(UserLoginDto userLogin)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == userLogin.Email.ToLower());

            if (user == null) return null;

            // if password is incorrect, return null user
            if (!VerifyPasswordHash(userLogin.Password, user.PasswordHash, user.PasswordSalt))
                return null;

            // get user, updaet lastlogintime etc
            user.LastLoginDt = DateTime.Now;
            await _context.SaveChangesAsync();

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        public async Task<User> Register(UserRegisterDto userRegister)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(userRegister.Password, out passwordHash, out passwordSalt);
            DateTime createDT = DateTime.Now;

            User user = new User()
            { 
                Email = userRegister.Email,
                Forename = userRegister.Forename,
                Surname = userRegister.Surname,
                AccountCreationDt = createDT,
                LastLoginDt = createDT,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                PrivilageLevel = userRegister.Email == "fake@user.com" ? (short)1 : (short)0,
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string email)
        {
            return await _context.Users.AnyAsync(x => x.Email == email);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
