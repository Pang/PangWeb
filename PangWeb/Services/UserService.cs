using PangWeb.Shared;
using PangWeb.Shared.DTOs;

namespace PangWeb.Services
{
    public class UserService
    {
        private List<User> _users;
        private User UserLoggedIn;

        public UserService()
        {
            _users = SeededData();
        }

        public List<User> GetUsers()
        {
            return _users;
        }

        public void RegisterUser(UserRegisterDto registerForm)
        {
            byte[] passwordHash, passwordSalt;
            // Creates hash here

            User user = new User()
            { 
                Id = _users.Count + 1,
                Forename = registerForm.Forename,
                Surname = registerForm.Surname,
                Email = registerForm.Email,
                AccountCreationDt = DateTime.UtcNow,
                LastLoginDt = DateTime.UtcNow,
            };

            if (!_users.Any(x => x.Email == user.Email)) 
                _users.Add(user);
        }

        public void LoginUser(UserLoginDto loginForm)
        {
            var user = _users.FirstOrDefault(x => x.Email == loginForm.Email);

            // will verifyPassword hash here
            UserLoggedIn = user;
        }

        private List<User> SeededData()
        {
            Random rand = new Random();
            return new List<User>()
            {
                new User
                {
                    Id = 1,
                    Email = "John.Smith@email.com",
                    Forename = "John",
                    Surname = "Smith",
                    AccountCreationDt = new DateTimeOffset(),
                    privilageLevel = 3
                },
            };
        }
    }
}
