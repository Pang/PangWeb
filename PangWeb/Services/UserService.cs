using System.Text;
using System.Text.Json;
using PangWeb.Shared;
using PangWeb.Shared.DTOs;

namespace PangWeb.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        private List<User> _users = new List<User>();
        private User UserLoggedIn;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _users = SeededData();
        }

        public List<User> GetUsers()
        {
            return _users;
        }

        public async Task<User> RegisterUser(UserRegisterDto registerForm)
        {
            Console.WriteLine("hit");
            var registerFormJson = new
                StringContent(JsonSerializer.Serialize(registerForm), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/user/register", registerFormJson);
            Console.WriteLine(1);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(2);
                return await JsonSerializer.DeserializeAsync<User>(await response.Content.ReadAsStreamAsync());
            }

            Console.WriteLine(3);
            return null;
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
                    AccountCreationDt = new DateTime(),
                    privilageLevel = 3
                },
            };
        }
    }
}
