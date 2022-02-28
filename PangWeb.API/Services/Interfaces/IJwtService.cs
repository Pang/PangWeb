using PangWeb.Shared;

namespace PangWeb.API.Services.Interfaces
{
    public interface IJwtService
    {
        public string CreateToken(User user);
    }
}
