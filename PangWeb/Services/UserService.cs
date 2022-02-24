using System.Text;
using System.Text.Json;
using PangWeb.Shared;
using PangWeb.Shared.DTOs;

namespace PangWeb.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        public UserDto UserLoggedIn = new ();

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            // try if LoginUser() returns null then:
            SeededData();
        }

        public async Task<List<UserDto>> GetAllUsersAdmin() 
        {
            var response = await _httpClient.GetAsync("api/User/allUsers");
            if (response.IsSuccessStatusCode)
                return await JsonSerializer.DeserializeAsync<List<UserDto>>(await response.Content.ReadAsStreamAsync());
            return null;
        }

        public async Task<UserDto> RegisterUser(UserRegisterDto registerForm)
        {
            var registerFormJson = new
                StringContent(JsonSerializer.Serialize(registerForm), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/User/register", registerFormJson);

            if (response.IsSuccessStatusCode)
                return await JsonSerializer.DeserializeAsync<UserDto>(await response.Content.ReadAsStreamAsync());

            return null;
        }

        public async Task<UserDto> LoginUser(UserLoginDto loginForm)
        {
            var loginFormJson = new
                StringContent(JsonSerializer.Serialize(loginForm), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/User/login", loginFormJson);

            if (response.IsSuccessStatusCode)
                return await JsonSerializer.DeserializeAsync<UserDto>(await response.Content.ReadAsStreamAsync());

            return null;
        }

        private async void SeededData()
        {
            var foo = new UserRegisterDto
            {
                Email = "pang.dev@mail.com",
                Forename = "Pang",
                Surname = "Dev",
                Password = "123",
            };
            await RegisterUser(foo);    
        }
    }
}
