using PangWeb.Shared;
using PangWeb.Shared.DTOs;

namespace PangWeb.API.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> Register(UserRegisterDto userRegister);
        Task<User> Login(UserLoginDto userLogin);
        Task<bool> UserExists(string email);
    }
}
