﻿using Proiect.Data.DTOs;
using Proiect.Helpers.Attributes;
using Proiect.Models.Enums;
using Proiect.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace Proiect.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Test([FromQuery]UserLoginDto userLoginDto)
        {
            return Ok("Users");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var response = await _userService.Login(userLoginDto);
            Console.WriteLine(response);

            if (response == null)
            {
                return BadRequest();
            }

            return Ok(response);
        }


        [AllowAnonymous]
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(UserRegisterDto userRegisterDto)
        {
            var response = await _userService.Register(userRegisterDto, Models.Enums.Role.User);

            if (response == false)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("create-admin")]
        public async Task<IActionResult> CreateAdmin(UserRegisterDto userRegisterDto)
        {
            var response = await _userService.Register(userRegisterDto, Models.Enums.Role.Admin);

            if (response == false)
            {
                return BadRequest();
            }

            return Ok(response);
        }


        [Authorize]
        [HttpGet("check-auth-without-role")]
        public IActionResult GetText()
        {
            return Ok("Account is logged in");
        }


        [Authorize(Role.User)]
        [HttpGet("check-auth-user")]
        public IActionResult GetTextUser()
        {
            return Ok("User is logged in");
        }

        [Authorize(Role.Admin)]
        [HttpGet("check-auth-admin")]
        public IActionResult GetTextAdmin()
        {
            return Ok("Admin is logged in");
        }

        [Authorize(Role.Admin, Role.User)]
        [HttpGet("check-auth-admin-and-user")]
        public IActionResult GetTextAdminUser()
        {
            return Ok("Account is user or admin");
        }
    }
}
