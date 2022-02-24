﻿using Microsoft.AspNetCore.Http;
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

            var createdUser = await _repo.Register(userRegister);
            var userDto = new UserDto(createdUser);

            return StatusCode(201);
        }

        [HttpPost("login")]
        [ProducesResponseType(401)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Login(UserLoginDto userLogin)
        {
            var userFromRepo = await _repo.Login(userLogin);
            if (userFromRepo == null) return Unauthorized();

            var userDto = new UserDto(userFromRepo);

            return Ok(userDto);
        }

        [HttpGet("allUsers")]
        [ProducesResponseType(401)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> AllUsers()
        {
            var usersFromRepo = await _repo.GetAllUsers();
            return Ok(usersFromRepo);
        }
    }
}
