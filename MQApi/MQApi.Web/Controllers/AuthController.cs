﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MQApi.Web.Repositories;

namespace MQApi.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository userRepository;
       private readonly ITokenHandler tokenHandler;

        public AuthController(IUserRepository userRepository, ITokenHandler tokenHandler)
        {
            this.userRepository = userRepository;
            this.tokenHandler = tokenHandler;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(Model.DTO.LoginRequest loginRequest)
        {
            //validate the incoming request we have used fluent validation

            // Check if user is authenticated
            // Check username and password

         
            var user = await userRepository.AuthenticateAsync(
                loginRequest.Username, loginRequest.Password);


            if (user != null)
            {
               // Generate a JWT Token
                 var token = await tokenHandler.CreateTokenAsync(user);
                return Ok(token);
            }

            return BadRequest("Username or Password is incorrect.");
        }
    }
}
