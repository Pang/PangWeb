using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PangWeb.API.Repositories.Interfaces;
using PangWeb.Shared.DTOs;

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

        [HttpPost("register")]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Register(UserRegisterDto userRegister)
        {
            userRegister.Email = userRegister.Email.ToLower();

            if (await _repo.UserExists(userRegister.Email))
                return BadRequest("Username already exists");

            var createdUser = _repo.Register(userRegister);

            return StatusCode(201);
        }

        [HttpPost("login")]
        [ProducesResponseType(401)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Login(UserLoginDto userLogin)
        {
            var userFromRepo = await _repo.Login(userLogin);
            if (userFromRepo == null) return Unauthorized();

            return Ok();
        }
    }
}
}
