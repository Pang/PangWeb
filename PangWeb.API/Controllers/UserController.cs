using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PangWeb.API.Repositories.Interfaces;

namespace PangWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        public UserController(IAuthRepository repo)
        {
            _repo = repo;
        }
    }
}
