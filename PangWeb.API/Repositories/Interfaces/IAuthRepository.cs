using PangWeb.Shared;

namespace PangWeb.API.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> Register(UserRegister userRegister);
        Task<User> Login(UserLogin userLogin);
        Task<bool> UserExists(string email);
    }
}
